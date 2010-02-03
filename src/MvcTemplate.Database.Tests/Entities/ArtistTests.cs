using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentNHibernate.Testing;
using NHibernate;
using Triggerfish.NHibernate;

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
	}
}
