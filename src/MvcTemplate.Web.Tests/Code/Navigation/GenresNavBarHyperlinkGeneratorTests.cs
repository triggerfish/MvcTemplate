using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTemplate.Model;
using MvcTemplate.Web.Tests;
using Moq;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class GenresNavBarHyperlinkGeneratorTests
	{
		[TestMethod]
		public void ShouldGenerateAllAndSecretLinksOnlyWhenNoRepository()
		{
			// arrange
			GenresNavBarHyperlinkGenerator gen = new GenresNavBarHyperlinkGenerator(null);

			// Act
			IEnumerable<Hyperlink> links = gen.Create(null);

			// Assert
			Assert.AreNotEqual(null, links);
			Assert.AreEqual(2, links.Count());
			Assert.AreEqual(links.First().Text, "All");
			Assert.AreEqual(links.Skip(1).First().Text, "Secret");
		}

		[TestMethod]
		public void ShouldGenerateNonSelectedLinksForAllGenres()
		{
			// Arrange
			List<string> genres = new List<string>() {
				"Genre1", "Genre2"
			};

			IArtistsRepository repos = MockArtistsRepository.CreateMockRepositoryGenresOnly(genres);

			GenresNavBarHyperlinkGenerator gen = new GenresNavBarHyperlinkGenerator(repos);

			// Act
			IEnumerable<Hyperlink> links = gen.Create(null);

			// Assert
			Assert.AreNotEqual(null, links);
			Assert.AreEqual(genres.Count + 2, links.Count());
			Hyperlink first = links.First();
			Assert.AreEqual(first.Text, "All");
			Assert.AreEqual(false, first.IsSelected);

			int i = 1;
			foreach (Hyperlink link in links.Skip(1).Take(2))
			{
				Assert.AreEqual(genres[i-1], link.Text);
				Assert.AreEqual(false, link.IsSelected);
				++i;
			}

			Hyperlink last = links.Last();
			Assert.AreEqual(last.Text, "Secret");
			Assert.AreEqual(false, last.IsSelected);
		}

		[TestMethod]
		public void ShouldGenerateSelectedGenreLink()
		{
			// Arrange
			List<string> genres = new List<string>() {
				"Genre1", "Genre2"
			};

			IArtistsRepository repos = MockArtistsRepository.CreateMockRepositoryGenresOnly(genres);
			Mock<IHyperlinkGeneratorArguments> args = new Mock<IHyperlinkGeneratorArguments>();
			args.Setup(x => x.Selected).Returns("Genre2");
			GenresNavBarHyperlinkGenerator gen = new GenresNavBarHyperlinkGenerator(repos);

			// Act
			IEnumerable<Hyperlink> links = gen.Create(args.Object);

			// Assert
			Assert.AreNotEqual(null, links);
			Assert.AreEqual(false, links.First().IsSelected);
			Assert.AreEqual(false, links.Skip(1).First().IsSelected);
			Assert.AreEqual(true, links.Skip(2).First().IsSelected);
		}
	}
}
