using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTemplate.Web.Controllers;
using MvcTemplate.Model;
using Triggerfish.Security;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class DefaultMembershipProviderTests
	{
		IUser m_user;
		Mock<IUserRepository> m_repository = new Mock<IUserRepository>();
		Mock<IEncryptor> m_encryptor = new Mock<IEncryptor>();

		[TestMethod]
		public void ShouldReturnUserIfValid()
		{
			// Arrange
			DefaultMembershipProvider membership = new DefaultMembershipProvider(m_repository.Object, m_encryptor.Object);
			
			// Act
			IUser user = membership.Validate(MockUsers.CreateMockUserCredentials("test@test.com", "password"));

			// Assert
			Assert.AreNotEqual(null, user);
			Assert.AreEqual(m_user.Credentials.Email, user.Credentials.Email);
		}

		[TestMethod]
		public void ShouldThrowIfUserDoesNotExist()
		{
			// Arrange
			DefaultMembershipProvider membership = new DefaultMembershipProvider(m_repository.Object, m_encryptor.Object);

			// Act
			try
			{
				IUser user = membership.Validate(MockUsers.CreateMockUserCredentials("invalid@test.com", "password"));
			}
			catch (AuthenticationException)
			{
				// expected, just return
				return;
			}

			// Assert
			Assert.Fail("Expected AuthenticationException");
		}

		[TestMethod]
		public void ShouldThrowIfPasswordsDoNotMatch()
		{
			// Arrange
			DefaultMembershipProvider membership = new DefaultMembershipProvider(m_repository.Object, m_encryptor.Object);

			// Act
			try
			{
				IUser user = membership.Validate(MockUsers.CreateMockUserCredentials("test@test.com", "invalid"));
			}
			catch (AuthenticationException)
			{
				// expected, just return
				return;
			}

			// Assert
			Assert.Fail("Expected AuthenticationException");
		}

		[TestInitialize]
		public void SetupTest()
		{
			m_user = MockUsers.CreateMockUser(MockUsers.CreateMockUserCredentials("test@test.com", "password"));
			string email = m_user.Credentials.Email;
			m_repository.Setup(x => x.Get(email)).Returns(m_user);
			m_repository.Setup(x => x.Get(It.Is<string>(s => s != email))).Returns<IUser>(null);

			m_encryptor.Setup(x => x.IsMatch("password", "password")).Returns(true);
			m_encryptor.Setup(x => x.IsMatch(It.Is<string>(s => s != "password"), "password")).Returns(false);
		}
	}
}
