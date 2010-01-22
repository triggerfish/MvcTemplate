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
	public class SearchControllerTests
	{
		[TestMethod]
		public void ShouldDisplayIndex()
		{
			// Arrange
			SearchController controller = new SearchController(null);

			// Act
			ViewResult result = controller.Index();

			// Assert
			Assert.AreEqual("", result.ViewName);
			SearchViewData vd = result.ViewData.Model as SearchViewData;
			Assert.AreNotEqual(null, vd);
			Assert.AreEqual(false, vd.DisplaySearch);
		}

		[TestMethod]
		public void ShouldRedirectFromSearchPost()
		{
			// Arrange
			Mock<ISearchResults> results = new Mock<ISearchResults>();
			Mock<IArtistsRepository> repository = new Mock<IArtistsRepository>();
			repository.Setup(r => r.Search(It.IsAny<string>())).Returns(results.Object);

			SearchController controller = new SearchController(repository.Object);

			// Act
			RedirectToRouteResult result = controller.Index("Pop") as RedirectToRouteResult;

			// Assert
			Assert.AreEqual("Results", (string)result.RouteValues["action"]);
			SearchViewData svd = controller.ViewData.Model as SearchViewData;
			Assert.AreNotEqual(null, svd);
			Assert.AreEqual(results.Object, svd.Results);
		}

		[TestMethod]
		public void ShouldDisplaySearchResults()
		{
			// Arrange
			SearchController controller = new SearchController(null);

			// Act
			controller.ViewData.Model = new SearchViewData();
			ViewResult result = controller.Results() as ViewResult;

			// Assert
			Assert.AreNotEqual(null, result);
			Assert.AreEqual("", result.ViewName);
		}

		[TestMethod]
		public void ShouldRedirectFromSearchResultsIfNoViewData()
		{
			// Arrange
			SearchController controller = new SearchController(null);

			// Act
			RedirectToRouteResult result = controller.Results() as RedirectToRouteResult;

			// Assert
			Assert.AreEqual("Index", (string)result.RouteValues["action"]);
		}
	}
}
