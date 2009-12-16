using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentNHibernate.Testing;
using NHibernate;

namespace MvcTemplate.Database.Tests
{
	[TestClass]
	public class ArtistTests : DatabaseTest
	{
		[TestMethod]
		public void ShouldCreateNewArtist()
		{
			new PersistenceSpecification<Artist>(Session)
				.CheckProperty(x => x.Id, 1) //identity starts at 1 - can't reset to zero
				.CheckProperty(x => x.Name, "1")
				.CheckProperty(x => x.Formed, DateTime.Today)
				.CheckProperty(x => x.NumberOnes, 3)
				.CheckReference(x => x.Genre, new Genre { Name = "Pop" })
				.VerifyTheMappings();
		}

		[TestMethod]
		public void ShouldChangeArtistData()
		{
			Genre popGenre = new Genre { Name = "Pop" };
			Artist popArtist = new Artist { Name = "1", Formed = DateTime.Today, NumberOnes = 4 };
			popGenre.AddArtist(popArtist);
			Session.WithinTransaction(s =>
			{
				s.Save(popGenre);
			});
			Session.Clear();

			Artist a = Session.Get<Artist>(1);
			a.Name = "2";
			a.NumberOnes = 12;
			Session.WithinTransaction(s => s.Update(a));
			Session.Clear();

			a = Session.Get<Artist>(1);
			Assert.AreNotEqual(null, a);
			Assert.AreEqual(a.Name, "2");
			Assert.AreEqual(a.NumberOnes, 12);
		}

		[TestMethod]
		public void ShouldChangeGenreOfArtist()
		{
			Genre popGenre = new Genre { Name = "Pop" };
			Genre rockGenre = new Genre { Name = "Rock" };
			Artist popArtist = new Artist {	Name = "1" };
			popGenre.AddArtist(popArtist);
			Session.WithinTransaction(s => {
				s.Save(popGenre);
				s.Save(rockGenre);
			});
			Session.Clear();

			Artist a = Session.Get<Artist>(1);
			Assert.AreEqual(a.Genre.Name, "Pop");
			a.Genre = rockGenre;
			Session.WithinTransaction(s => s.Update(a));
			Session.Clear();

			a = Session.Get<Artist>(1);
			Assert.AreNotEqual(null, a);
			Assert.AreEqual(a.Name, "1");
			Assert.AreEqual(a.Genre.Name, "Rock");
		}
	}
}
