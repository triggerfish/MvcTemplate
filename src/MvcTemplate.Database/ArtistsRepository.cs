using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NHibernate;
using NHibernate.Linq;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class ArtistsRepository : Repository, IArtistsRepository
	{
		public ArtistsRepository(ISession a_session)
			: base(a_session)
		{
		}

		public ArtistsRepository(IDbSession a_session)
			: base(a_session)
		{
		}

		public IEnumerable<Artist> Artists
		{
			get { return GetAll<Artist>(); }
		}

		public IEnumerable<Genre> Genres
		{
			get { return GetAll<Genre>(); }
		}

		public IEnumerable<Artist> GetArtistsByGenre(string a_genre)
		{
			return Artists.Where(a => a.Genre.Name == a_genre);
		}

		public IEnumerable<Artist> GetArtistsByGenre(int a_genreID)
		{
			return Genres.Where(g => g.Id == a_genreID).First().Artists;
		}

		public ISearchResults Search(string a_keyword)
		{
			SearchResults results = new SearchResults();

			// no join operator in LINQ to NHibernate

			string k = a_keyword.ToLower();
			results.Artists = Artists.Where(a => a.Name.ToLower().Contains(k)).Cast<IArtist>();
			results.Genres = Genres.Where(g => g.Name.ToLower().Contains(k)).Cast<IGenre>();

			return results;
		}

		#region IArtistsRepository Explicit Implementation

		IEnumerable<IArtist> IArtistsRepository.Artists
		{
			get
			{
				return Artists.Cast<IArtist>();
			}
		}

		IEnumerable<IGenre> IArtistsRepository.Genres
		{
			get
			{
				return Genres.Cast<IGenre>();
			}
		}

		IEnumerable<IArtist> IArtistsRepository.GetArtistsByGenre(string a_genre)
		{
			return GetArtistsByGenre(a_genre).Cast<IArtist>();
		}

		IEnumerable<IArtist> IArtistsRepository.GetArtistsByGenre(int a_genreID)
		{
			return GetArtistsByGenre(a_genreID).Cast<IArtist>();
		}

		#endregion
	}
}
