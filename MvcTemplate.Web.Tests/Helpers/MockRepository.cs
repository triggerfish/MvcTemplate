using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Moq;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Tests
{
	internal static class MockRepository
	{
		public static IRepository CreateMockRepositoryGenresOnly(IEnumerable<string> a_genreNames)
		{
			IEnumerable<IGenre> genres = MockGenre.CreateMockGenres(a_genreNames);
			Mock<IRepository> repository = new Mock<IRepository>();
			repository.Setup(r => r.Genres).Returns(genres);
			return repository.Object;
		}

		public static IRepository CreateMockRepository(string a_genre, IEnumerable<string> a_artistNames)
		{
			IEnumerable<IArtist> artists = MockArtist.CreateMockArtists(a_artistNames);
			Mock<IRepository> repository = new Mock<IRepository>();

			IGenre g = MockGenre.CreateMockGenre(0, a_genre, artists);

			repository.Setup(r => r.Genres).Returns(new List<IGenre> { g });
			repository.Setup(r => r.Artists).Returns(artists);
			repository.Setup(r => r.GetArtistsByGenre(g.Id)).Returns(artists);
			repository.Setup(r => r.GetArtistsByGenre(g.Name)).Returns(artists);
			
			return repository.Object;
		}
	
		public static IRepository CreateMockRepository(Dictionary<string, IEnumerable<string>> a_genreArtistMap)
		{
			Mock<IRepository> repository = new Mock<IRepository>();

			Dictionary<IGenre, IEnumerable<IArtist>> map = new Dictionary<IGenre, IEnumerable<IArtist>>();
			List<IArtist> allArtists = new List<IArtist>();

			foreach (KeyValuePair<string, IEnumerable<string>> kvp in a_genreArtistMap)
			{
				IEnumerable<IArtist> artists = MockArtist.CreateMockArtists(kvp.Value);
				IGenre g = MockGenre.CreateMockGenre(0, kvp.Key, artists);

				map.Add(g, artists);
				allArtists.AddRange(artists);

				repository.Setup(r => r.GetArtistsByGenre(g.Id)).Returns(artists);
				repository.Setup(r => r.GetArtistsByGenre(g.Name)).Returns(artists);
			}

			repository.Setup(r => r.Genres).Returns(map.Keys);
			repository.Setup(r => r.Artists).Returns(allArtists);

			return repository.Object;
		}
	}
}
