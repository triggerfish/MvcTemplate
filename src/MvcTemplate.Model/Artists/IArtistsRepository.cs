using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IArtistsRepository
	{
		IEnumerable<IArtist> Artists { get; }
		IEnumerable<IGenre> Genres { get; }

		IEnumerable<IArtist> GetArtistsByGenre(int genreID);
		IEnumerable<IArtist> GetArtistsByGenre(string genreName);

		ISearchResults Search(string keywords);
	}
}
