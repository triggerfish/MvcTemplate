using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTemplate.Model;
using MvcTemplate.Web.Tests;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class GenreHyperlinksTests
	{
		[TestMethod]
		public void ShouldGenerateAllLinkOnlyWhenNoRepository()
		{
			// Act
			IList<Hyperlink> links = GenreHyperlinks.CreateLinks(null);

			// Assert
			Assert.AreNotEqual(null, links);
			Assert.AreEqual(1, links.Count);
			Assert.AreEqual(links[0].Text, "All");
		}

		[TestMethod]
		public void ShouldGenerateNonSelectedLinksForAllGenres()
		{
			// Arrange
			List<string> genres = new List<string>() {
				"Genre1", "Genre2"
			};

			IRepository repos = MockRepository.CreateMockRepositoryGenresOnly(genres);

			// Act
			IList<Hyperlink> links = GenreHyperlinks.CreateLinks(repos);

			// Assert
			Assert.AreNotEqual(null, links);
			Assert.AreEqual(genres.Count + 1, links.Count);
			Assert.AreEqual(links[0].Text, "All");
			Assert.AreEqual(false, links[0].IsSelected);

			for (int i = 1; i <= genres.Count; i++)
			{
				Assert.AreEqual(genres[i-1], links[i].Text);
				Assert.AreEqual(false, links[i].IsSelected);
			}
		}

		[TestMethod]
		public void ShouldGenerateSelectedGenreLink()
		{
			// Arrange
			List<string> genres = new List<string>() {
				"Genre1", "Genre2"
			};

			IRepository repos = MockRepository.CreateMockRepositoryGenresOnly(genres);

			// Act
			IList<Hyperlink> links = GenreHyperlinks.CreateLinks(repos, "genre2");

			// Assert
			Assert.AreNotEqual(null, links);
			Assert.AreEqual(false, links[0].IsSelected);
			Assert.AreEqual(false, links[1].IsSelected);
			Assert.AreEqual(true, links[2].IsSelected);
		}
	}
}
