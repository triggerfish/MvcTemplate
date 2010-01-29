using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTemplate.Web.Controllers;
using Moq;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class UserCredentialsBinderTests
	{
		[TestMethod]
		public void ShouldBindCredentials()
		{
			// Arrange
			string email = "test@test.com";
			string password = "password";

			IUserCredentials creds = MockUsers.CreateMockUserCredentials(email, password);
			Mock<IUserRepository> repository = new Mock<IUserRepository>();
			repository.Setup(r => r.CreateUserCredentials(It.IsAny<string>(), It.IsAny<string>())).Returns(creds);

			UserCredentialsBinder binder = new UserCredentialsBinder(repository.Object, null);

			ModelBindingContext ctx = BinderHelpers.CreateModelBindingContext("credentials", new Dictionary<string, string> {
				{ "Email", email },
				{ "Password", password }
			});
			
			// Act
			IUserCredentials u = binder.BindModel(null, ctx) as IUserCredentials;

			// Assert
			Assert.AreNotEqual(null, u);
			Assert.AreEqual(true, ctx.ModelState.IsValid);
			Assert.AreEqual(email, u.Email);
			Assert.AreEqual(password, u.Password);
		}
	}
}
