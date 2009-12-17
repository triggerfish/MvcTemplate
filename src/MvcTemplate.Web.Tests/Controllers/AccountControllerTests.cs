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
	public class AccountControllerTests
	{
		[TestMethod]
		public void ShouldDisplayLogin()
		{
			// Arrange
			AccountController controller = new AccountController(null);

			// Act
			ViewResult result = controller.Login();

			// Assert
			Assert.AreEqual("", result.ViewName);
		}
	}
}
