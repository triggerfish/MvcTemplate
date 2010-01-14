using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTemplate.Web.Controllers;
using Moq;
using MvcTemplate.Model;
using System.Globalization;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class UserBinderTests
	{
		[TestMethod]
		public void ShouldBindUser()
		{
			// Arrange
			string email = "test@test.com";
			string password = "password";

			Mock<IEncryptor> encryptor = new Mock<IEncryptor>();
			encryptor.Setup(x => x.Encrypt(It.IsAny<string>())).Returns<string>(s => s);

			IUser user = MockUsers.CreateMockUser(new UserCredentials { Email = email, Password = password });
			Mock<IUserRepository> repository = new Mock<IUserRepository>();
			repository.Setup(r => r.CreateNew(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<UserCredentials>())).Returns(user);

			UserBinder binder = new UserBinder(repository.Object, encryptor.Object);

			ModelBindingContext ctx = BinderHelpers.CreateModelBindingContext("user", new Dictionary<string, string> {
				{ "Email", email },
				{ "Password", password }
			});
			
			// Act
			IUser u = binder.BindModel(null, ctx) as IUser;

			// Assert
			Assert.AreNotEqual(null, u);
			Assert.AreEqual(true, ctx.ModelState.IsValid);
			Assert.AreEqual(email, u.Credentials.Email);
			Assert.AreEqual(password, u.Credentials.Password);

			encryptor.Verify(x => x.Encrypt(password));
		}
	}
}
