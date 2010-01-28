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
		public void ShouldListAllArtists()
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

			IArtistsRepository repos = MockArtistsRepository.CreateMockRepository(genreArtistMap);

			ArtistsController controller = new ArtistsController(repos);

			// Act
			ViewResult result = controller.AllArtists(1);

			// Assert
			Assert.AreEqual("", result.ViewName);
		}

		[TestMethod]
		public void ShouldListArtistsInGenre()
		{
			// Arrange
			List<string> artists = new List<string>() {
				"Artist1", "Artist2"
			};

			IGenre g = MockGenre.CreateMockGenre(1, "Pop", MockArtist.CreateMockArtists(artists));

			ArtistsController controller = new ArtistsController(null);

			// Act
			ViewResult result = controller.Genre(g); // lower case - urls are lower-case

			GenreViewData vd = result.ViewData.Model as GenreViewData;

			// Assert
			Assert.AreEqual("", result.ViewName);
			Assert.AreNotEqual(null, vd);
			Assert.AreEqual(g.Name, vd.SelectedGenre); // camel case - this will be displayed to the user

			ValidateArtistsList(artists, vd.Artists.ToList());
		}

		[TestMethod]
		public void ShouldDisplaySingleArtist()
		{
			// Arrange
			IArtist a = MockArtist.CreateMockArtist(1, "Artist");

			ArtistsController controller = new ArtistsController(null);

			// Act
			ViewResult result = controller.Artist(a);

			ArtistViewData vd = result.ViewData.Model as ArtistViewData;

			// Assert
			Assert.AreEqual("", result.ViewName);
			Assert.AreNotEqual(null, vd);
			Assert.AreEqual(1, vd.Artist.Id);
			Assert.AreEqual("Artist", vd.Artist.Name);
		}

		[TestMethod]
		public void ShouldDisplaySecret()
		{
			// Arrange
			ArtistsController controller = new ArtistsController(null);

			// Act
			ViewResult result = controller.Secret();

			// Assert
			Assert.AreEqual("", result.ViewName);
		}

		private void ValidateArtistsList(IList<string> expected, IList<IArtist> actual)
		{
			Assert.AreEqual(expected.Count, actual.Count);
			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(expected[i], actual[i].Name);
			}
		}
	}
}
