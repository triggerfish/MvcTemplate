using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentNHibernate.Testing;
using NHibernate;
using MvcTemplate.Model;
using Triggerfish.NHibernate;
using Triggerfish.Validator;
using Moq;

namespace MvcTemplate.Database.Tests
{
	[TestClass]
	public class GenreTests : DatabaseTest
	{
		[TestMethod]
		public void ShouldCreateGenreWithArtists()
		{
			Genre savedGenre = new Genre { Name = "Pop" };
			List<Artist> artists = new List<Artist> {
					new Artist { Name = "1" }, 
					new Artist { Name = "2" } 
				};
			savedGenre.AddArtists(artists);
			Session.SaveOrUpdate(savedGenre);
			m_uow.Commit();
			Session.Clear();

			Genre retrievedGenre = Session.Get<Genre>(1);

			Assert.AreNotEqual(null, retrievedGenre);
			Assert.IsFalse(ReferenceEquals(savedGenre, retrievedGenre));
			Assert.AreEqual(savedGenre.Name, retrievedGenre.Name);
			Assert.AreEqual(savedGenre.Artists.Count, retrievedGenre.Artists.Count);
			Assert.IsFalse(ReferenceEquals(savedGenre.Artists[0], retrievedGenre.Artists[0]));
			Assert.AreEqual(savedGenre.Artists[0].Name, retrievedGenre.Artists[0].Name);
			Assert.IsFalse(ReferenceEquals(savedGenre.Artists[1], retrievedGenre.Artists[1]));
			Assert.AreEqual(savedGenre.Artists[1].Name, retrievedGenre.Artists[1].Name);

			//new PersistenceSpecification<Genre>(Session)
			//    .CheckProperty(g => g.Id, 1) //identity starts at 1 - can't reset to zero
			//    .CheckProperty(g => g.Name, "Genre")
			//    .CheckList(g => g.Artists, artists, (g, a) => g.AddArtist(a))
			//    .VerifyTheMappings();
		}
	}
}
