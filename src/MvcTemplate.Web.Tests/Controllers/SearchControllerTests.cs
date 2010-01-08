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
		public void ShouldPerformSearchOfArtistsAndGenres()
		{
			// Arrange
			string keywords = "Pop";

			Mock<ISearchResults> results = new Mock<ISearchResults>();
			results.Setup(r => r.Artists).Returns(MockArtist.CreateMockArtists(new List<string> { "Poppy" }));
			results.Setup(r => r.Genres).Returns(MockGenre.CreateMockGenres(new List<string> { "Pop" }));

			Mock<IArtistsRepository> repository = new Mock<IArtistsRepository>();
			repository.Setup(r => r.Search(keywords)).Returns(results.Object);

			SearchController controller = new SearchController(repository.Object);

			// Act
			ViewResult result = controller.Index("Pop");

			// Assert
			Assert.AreEqual("Results", result.ViewName);
			SearchViewData vd = result.ViewData.Model as SearchViewData;
			Assert.AreNotEqual(null, vd);
			Assert.AreEqual(false, vd.DisplaySearch);
			Assert.AreEqual(1, vd.Results.Artists.Count());
			Assert.AreEqual(1, vd.Results.Genres.Count());

			Assert.AreEqual("Poppy", vd.Results.Artists.First().Name);
			Assert.AreEqual("Pop", vd.Results.Genres.First().Name);
		}
	}
}
