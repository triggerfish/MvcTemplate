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
	public class HomeControllerTests
	{
		[TestMethod]
		public void ShouldDisplayIndex()
		{
			// Arrange
			HomeController controller = new HomeController(null);

			// Act
			ViewResult result = controller.Index();

			// Assert
			Assert.AreEqual("", result.ViewName);
			ViewData vd = result.ViewData.Model as ViewData;
			Assert.AreNotEqual(null, vd);
		}
	}
}
