using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using MvcTemplate.Model;

namespace MvcTemplate.Database.Tests
{
	[TestClass]
	public class RepositoryTests : DatabaseTest
	{
		private Repository m_repository;

		[TestMethod]
		public void ShouldReturnSettings()
		{
			Assert.AreNotEqual(null, m_repository.Settings);
		}

		[TestMethod]
		public void ShouldReturnUserRepository()
		{
			Assert.AreNotEqual(null, m_repository.UserRepository);
		}

		[TestMethod]
		public void ShouldReturnAllArtists()
		{
			ValidateArtists(m_repository.Artists, 4);
		}

		[TestMethod]
		public void ShouldReturnAllGenres()
		{
			IEnumerable<IGenre> genres = m_repository.Genres;

			Assert.AreNotEqual(null, genres);
			Assert.AreEqual(2, genres.Count());
			Assert.IsNotNull(genres.FirstOrDefault(g => g.Name == "Pop"));
			Assert.IsNotNull(genres.FirstOrDefault(g => g.Name == "Rock"));
		}

		[TestMethod]
		public void ShouldReturnArtistsUsingString()
		{
			ValidateArtists(m_repository.GetArtistsByGenre("Pop"), 2);
		}

		[TestMethod]
		public void ShouldReturnArtistsUsingId()
		{
			ValidateArtists(m_repository.GetArtistsByGenre(1), 2);
		}

		[TestMethod]
		public void ShouldSearchForGenre()
		{
			ISearchResults results = m_repository.Search("P");

			Assert.AreNotEqual(null, results);
			Assert.AreEqual(1, results.Genres.Count());
			Assert.AreEqual(0, results.Artists.Count());
		}

		[TestMethod]
		public void ShouldSearchForArtist()
		{
			ISearchResults results = m_repository.Search("2");

			Assert.AreNotEqual(null, results);
			Assert.AreEqual(0, results.Genres.Count());
			Assert.AreEqual(1, results.Artists.Count());
		}

		[TestMethod]
		public void ShouldNotSearchForMultipleKeywords()
		{
			ISearchResults results = m_repository.Search("P 2");

			Assert.AreNotEqual(null, results);
			Assert.AreEqual(0, results.Genres.Count());
			Assert.AreEqual(0, results.Artists.Count());
		}

		protected override void SetupContext(ISession a_session)
		{
			m_repository = new Repository(a_session);

			SortedDictionary<int, Artist> artists = new SortedDictionary<int, Artist>();
			for (int i = 1; i <= 4; i++)
			{
				artists.Add(i, new Artist { Name = i.ToString() });
			}

			Genre pop = new Genre { Name = "Pop" };
			pop.AddArtists(artists.Values.Take(2));

			Genre rock = new Genre { Name = "Rock" };
			rock.AddArtists(artists.Values.Skip(2).Take(2));

			a_session.Save(pop);
			a_session.Save(rock);
		}

		private void ValidateArtists(IEnumerable<IArtist> a_artists, int a_iExpectedCount)
		{
			Assert.AreNotEqual(null, a_artists);
			Assert.AreEqual(a_iExpectedCount, a_artists.Count());

			int i = 1;
			foreach (IArtist a in a_artists)
			{
				Assert.AreEqual(i.ToString(), a.Name);
				Assert.AreEqual(i++, a.Id);
			}
		}
	}
}
