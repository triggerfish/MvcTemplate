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
	public class Repository : IRepository
	{
		private RepositorySettings m_settings = new RepositorySettings();
		private DataContext m_context;

		public Repository(ISession a_session)
		{
			m_context = new DataContext(a_session);
		}

		public Repository(IDbSession a_session)
			: this(a_session.CreateSession())
		{
		}

		public IRepositorySettings Settings
		{
			get { return m_settings; }
		}

		public IUserRepository UserRepository 
		{
			get { return null; }
		}

		public IEnumerable<IArtist> Artists
		{
			get 
			{
				return m_context.Artists.Cast<IArtist>();
			}
		}

		public IEnumerable<IGenre> Genres
		{
			get 
			{
				return m_context.Genres.Cast<IGenre>();
			}
		}

		public IEnumerable<IArtist> GetArtistsByGenre(string a_genre)
		{
			return m_context.Artists.Where(a => a.Genre.Name == a_genre).Cast<IArtist>();
		}

		public IEnumerable<IArtist> GetArtistsByGenre(int a_genreID)
		{
			return m_context.Genres.Where(g => g.Id == a_genreID).First().Artists.Cast<IArtist>();
		}

		public ISearchResults Search(string a_keyword)
		{
			SearchResults results = new SearchResults();

			// no join operator in LINQ to NHibernate

			string k = a_keyword.ToLower();
			results.Artists = m_context.Artists.AsEnumerable().Where(a => a.Name.ToLower().Contains(k)).Cast<IArtist>();
			results.Genres = m_context.Genres.AsEnumerable().Where(g => g.Name.ToLower().Contains(k)).Cast<IGenre>();

			return results;
		}
	}
}
