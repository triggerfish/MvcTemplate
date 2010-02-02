using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NHibernate;
using NHibernate.Linq;
using Triggerfish.FluentNHibernate;
using Triggerfish.Validator;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class ArtistsRepository : Repository, IArtistsRepository
	{
		public ArtistsRepository(ISession session, IValidator validator)
			: base(session, validator)
		{
		}

		public ArtistsRepository(IDbSession session, IValidator validator)
			: base(session, validator)
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

		public IEnumerable<Artist> GetArtistsByGenre(string genre)
		{
			return Artists.Where(a => a.Genre.Name == genre);
		}

		public IEnumerable<Artist> GetArtistsByGenre(int genreID)
		{
			return Genres.Where(g => g.Id == genreID).First().Artists;
		}

		public ISearchResults Search(string keyword)
		{
			SearchResults results = new SearchResults();

			// no join operator in LINQ to NHibernate

			string k = keyword.ToLower();
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

		IEnumerable<IArtist> IArtistsRepository.GetArtistsByGenre(string genre)
		{
			return GetArtistsByGenre(genre).Cast<IArtist>();
		}

		IEnumerable<IArtist> IArtistsRepository.GetArtistsByGenre(int genreID)
		{
			return GetArtistsByGenre(genreID).Cast<IArtist>();
		}

		#endregion
	}
}
