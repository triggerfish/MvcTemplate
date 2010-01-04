using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IRepository
	{
		IRepositorySettings Settings { get; }
		IUserRepository UserRepository { get; }
		IEnumerable<IArtist> Artists { get; }
		IEnumerable<IGenre> Genres { get; }

		IEnumerable<IArtist> GetArtistsByGenre(int a_genreID);
		IEnumerable<IArtist> GetArtistsByGenre(string a_genreName);

		ISearchResults Search(string a_keywords);
	}
}
