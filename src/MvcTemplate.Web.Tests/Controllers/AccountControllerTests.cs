using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTemplate.Model;
using MvcTemplate.Web.Controllers;
using Triggerfish.Testing.Web.Routing;
using System.Linq.Expressions;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class AccountControllerTests
	{
		private Mock<IUserRepository> m_repository = new Mock<IUserRepository>();
		private Mock<IEncryptor> m_encryptor = new Mock<IEncryptor>();
		private Mock<IAuthenticationProvider> m_authentication = new Mock<IAuthenticationProvider>();
		private Mock<IMembershipProvider> m_membership = new Mock<IMembershipProvider>();
		private IUser m_user;

		#region Login tests

		[TestMethod]
		public void ShouldDisplayLogin()
		{
			// Arrange
			AccountController controller = new AccountController(null, null);

			// Act
			ViewResult result = controller.Login();

			// Assert
			Assert.AreEqual("", result.ViewName);
		}

		[TestMethod]
		public void ShouldLoginIfCredentialsCorrect()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);

			// Act
			ActionResult result = controller.Login(m_user.Credentials, "");

			// Assert
			m_membership.Verify(x => x.Validate(m_user.Credentials));
			m_authentication.Verify(x => x.Login(m_user.Forename, false));
		}

		[TestMethod]
		public void ShouldFailToLoginIfEmailIncorrect()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);
			IUserCredentials uc = MockUsers.CreateMockUserCredentials("test", "password");

			// Act
			ActionResult result = controller.Login(uc, "");

			// Assert
			m_membership.Verify(x => x.Validate(uc));
			m_authentication.Verify(x => x.Login(m_user.Forename, false), Times.Never());
		}

		[TestMethod]
		public void ShouldFailToLoginIfPasswordIncorrect()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);
			IUserCredentials uc = MockUsers.CreateMockUserCredentials(m_user.Credentials.Email, "wrong");

			// Act
			ActionResult result = controller.Login(uc, "");

			// Assert
			m_membership.Verify(x => x.Validate(uc));
			m_authentication.Verify(x => x.Login(m_user.Forename, false), Times.Never());
		}

		[TestMethod]
		public void ShouldRedisplayLoginPageOnLoginFailure()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);
			IUserCredentials uc = MockUsers.CreateMockUserCredentials("test", "password");

			// Act
			ViewResult result = controller.Login(uc, "") as ViewResult;

			// Assert
			Assert.AreEqual("", result.ViewName);
			Assert.IsFalse(result.ViewData.ModelState.IsValid);
			Assert.AreEqual(1, result.ViewData.ModelState["Email"].Errors.Count);
		}

		[TestMethod]
		public void ShouldRedirectToUrlOnSuccessfulLogin()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);

			// Act
			ShouldRedirectToUrl(controller.Login, m_user.Credentials);
		}

		[TestMethod]
		public void ShouldRedirectToHomePageOnSuccessfulLogin()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);

			// Act
			ShouldRedirectToHomePage(controller.Login, m_user.Credentials);
		}
		#endregion

		#region Logout tests
		[TestMethod]
		public void ShouldLogout()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, null);

			// Act
			controller.Logout("");

			// Assert
			m_authentication.Verify(x => x.Logout());
		}

		[TestMethod]
		public void ShouldRedirectOnLogout()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, null);

			// Act
			RedirectResult result = controller.Logout("/redirect") as RedirectResult;

			// Assert
			Assert.AreNotEqual(null, result);
			Assert.AreEqual("/redirect", result.Url);
		}

		[TestMethod]
		public void ShouldRedirectToHomeOnLogout()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, null);

			// Act
			RedirectToRouteResult result = controller.Logout(null) as RedirectToRouteResult;

			// Assert
			Assert.AreNotEqual(null, result);
			RoutingAssert.AreDictionariesEqual(RouteHelpers.HomeRoute(), result.RouteValues);
		}

		#endregion

		#region Register tests

		[TestMethod]
		public void ShouldDisplayRegister()
		{
			// Arrange
			AccountController controller = new AccountController(null, null);

			// Act
			ViewResult result = controller.Register();

			// Assert
			Assert.AreEqual("", result.ViewName);
		}

		[TestMethod]
		public void ShouldRegisterAndLoginIfBindingCorrect()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);
			IUser newUser = MockUsers.CreateMockUser("new@test.com", "password");
			newUser.Forename = "New";

			// Act
			ActionResult result = controller.Register(newUser, "");

			// Assert
			m_membership.Verify(x => x.Register(newUser));
			m_authentication.Verify(x => x.Login(newUser.Forename, false));
		}

		[TestMethod]
		public void ShouldFailToRegisterIfBindingFailed()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);

			// Act
			ActionResult result = controller.Register(MockUsers.CreateMockUser("invalid", "password"), "");

			// Assert
			m_membership.Verify(x => x.Register(m_user), Times.Never());
		}

		[TestMethod]
		public void ShouldFailToRegisterIfEmailAlreadyRegistered()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);

			// Act
			ActionResult result = controller.Register(m_user, "");

			// Assert
			m_membership.Verify(x => x.Register(m_user));
			m_authentication.Verify(x => x.Login(m_user.Forename, false), Times.Never());
		}

		[TestMethod]
		public void ShouldRedisplayRegisterPageOnFailure()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);

			// Act
			ViewResult result = controller.Register(m_user, "") as ViewResult;

			// Assert
			Assert.AreEqual("", result.ViewName);
			Assert.IsFalse(result.ViewData.ModelState.IsValid);
			Assert.AreEqual(1, result.ViewData.ModelState["Email"].Errors.Count);
		}

		[TestMethod]
		public void ShouldRedirectToUrlOnSuccessfulRegister()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);

			// Act
			ShouldRedirectToUrl(controller.Register, MockUsers.CreateMockUser("new@test.com", "password"));
		}

		[TestMethod]
		public void ShouldRedirectToHomePageOnSuccessfulRegister()
		{
			// Arrange
			AccountController controller = new AccountController(m_authentication.Object, m_membership.Object);

			// Act
			ShouldRedirectToHomePage(controller.Register, MockUsers.CreateMockUser("new@test.com", "password"));
		}

		#endregion

		[TestInitialize]
		public void SetupTest()
		{
			m_user = MockUsers.CreateMockUser(MockUsers.CreateMockUserCredentials("test@test.com", "password"));
			string email = m_user.Credentials.Email;
			m_repository.Setup(x => x.Get(email)).Returns(m_user);
			m_repository.Setup(x => x.Get(It.Is<string>(s => s != email))).Throws(new Exception(""));
			m_membership.Setup(x => x.Validate(m_user.Credentials)).Returns(m_user);
			m_membership.Setup(x => x.Validate(It.Is<IUserCredentials>(uc => uc != m_user.Credentials))).Throws(new AuthenticationException());
			m_membership.Setup(x => x.Register(m_user)).Throws(new ValidationException("Email", "Email already registered"));
		}

		private void ShouldRedirectToUrl<TParam>(Func<TParam, string, ActionResult> a_actionMethod, TParam a_param)
		{
			// Act
			RedirectResult result = a_actionMethod(a_param, "/redirect") as RedirectResult;

			// Assert
			Assert.AreNotEqual(null, result);
			Assert.AreEqual("/redirect", result.Url);
		}

		public void ShouldRedirectToHomePage<TParam>(Func<TParam, string, ActionResult> a_actionMethod, TParam a_param)
		{
			// Act
			RedirectToRouteResult result = a_actionMethod(a_param, null) as RedirectToRouteResult;

			// Assert
			Assert.AreNotEqual(null, result);
			RoutingAssert.AreDictionariesEqual(RouteHelpers.HomeRoute(), result.RouteValues);
		}	
	}
}
