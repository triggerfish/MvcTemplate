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
	public class ArtistsControllerTests
	{
		[TestMethod]
		public void ShouldListAllArtistsForAllGenre()
		{
			// Arrange
			List<string> artists = new List<string>
			{
				"1", "2", "3", "4"
			};

			Dictionary<string, IEnumerable<string>> genreArtistMap = new Dictionary<string, IEnumerable<string>>
			{
				{ "Pop", artists.Take(2) },
				{ "Rock", artists.Skip(2).Take(2) }
			};

			IRepository repos = MockRepository.CreateMockRepository(genreArtistMap);

			// Act & Assert
			ActAndValidateAction(repos, "All", artists);
		}

		[TestMethod]
		public void ShouldListArtistsInGenre()
		{
			// Arrange
			List<string> artists = new List<string>() {
				"Artist1", "Artist2"
			};

			IRepository repos = MockRepository.CreateMockRepository("Pop", artists);

			// Act & Assert
			ActAndValidateAction(repos, "Pop", artists);
		}

		[TestMethod]
		public void ShouldDisplayErrorWhenInvalidGenreEntered()
		{
			IRepository repos = MockRepository.CreateMockRepositoryGenresOnly(new List<string> { "1" });

			ArtistsController controller = new ArtistsController(repos);

			// Act
			ViewResult result = controller.Genre("plibble"); // lower case - urls are lower-case

			ErrorViewData vd = result.ViewData.Model as ErrorViewData;

			// assert
			Assert.AreEqual("Error", result.ViewName);
			Assert.AreNotEqual(null, vd);
			Assert.AreNotEqual(null, vd.Exception);
		}

		[TestMethod]
		public void ShouldDisplaySpecificArtist()
		{
			// Arrange
			List<string> artists = new List<string>() {
				"Artist1", "Artist2"
			};

			IRepository repos = MockRepository.CreateMockRepository("Pop", artists);
			ArtistsController controller = new ArtistsController(repos);

			// Act
			ViewResult result = controller.Artist("Artist2");

			ArtistViewData vd = result.ViewData.Model as ArtistViewData;

			// Assert
			Assert.AreEqual("", result.ViewName);
			Assert.AreNotEqual(null, vd);
			Assert.AreEqual(2, vd.Artist.Id);
			Assert.AreEqual("Artist2", vd.Artist.Name);
		}

		[TestMethod]
		public void ShouldDisplayErrorWhenInvalidArtistEntered()
		{
			// Arrange
			List<string> artists = new List<string>() {
				"Artist1", "Artist2"
			};

			IRepository repos = MockRepository.CreateMockRepository("Pop", artists);
			ArtistsController controller = new ArtistsController(repos);

			// Act
			ViewResult result = controller.Artist("Plibble");

			// assert
			Assert.AreEqual("Error", result.ViewName);
			ErrorViewData vd = result.ViewData.Model as ErrorViewData;
			Assert.AreNotEqual(null, vd);
			Assert.AreNotEqual(null, vd.Exception);
		}

		private void ActAndValidateAction(IRepository a_repository, string a_genre, IList<string> a_expectedArtistNames)
		{
			ArtistsController controller = new ArtistsController(a_repository);

			// Act
			ViewResult result = controller.Genre(a_genre.ToLower()); // lower case - urls are lower-case

			GenreViewData vd = result.ViewData.Model as GenreViewData;

			// Assert
			Assert.AreEqual("", result.ViewName);
			Assert.AreNotEqual(null, vd);
			Assert.AreEqual(a_genre, vd.SelectedGenre); // camel case - this will be displayed to the user

			List<IArtist> actualArtists = vd.Artists.ToList();
			Assert.AreEqual(a_expectedArtistNames.Count, actualArtists.Count);
			for (int i = 0; i < a_expectedArtistNames.Count; i++)
			{
				Assert.AreEqual(a_expectedArtistNames[i], actualArtists[i].Name);
			}
		}
	}
}
