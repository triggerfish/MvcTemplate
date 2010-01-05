using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTemplate.Web.Controllers;
using Moq;
using MvcTemplate.Model;
using System.Globalization;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class ArtistBinderTests
	{
		[TestMethod]
		public void ShouldBindArtist()
		{
			// Arrange
			List<string> artists = new List<string>() {
				"Artist1", "Artist2"
			};

			IArtistsRepository repos = MockRepository.CreateMockRepository("Pop", artists);
			ArtistBinder binder = new ArtistBinder(repos);

			ModelBindingContext ctx = BinderHelpers.CreateModelBindingContext("artist", "artist2");
			
			// Act
			IArtist a = binder.BindModel(null, ctx) as IArtist;

			// Assert
			Assert.AreNotEqual(null, a);
			Assert.AreEqual(true, ctx.ModelState.IsValid);
			Assert.AreEqual(2, a.Id);
			Assert.AreEqual("Artist2", a.Name);
		}

		[TestMethod]
		public void ShouldFailToBindArtist()
		{
			// Arrange
			List<string> artists = new List<string>() {
				"Artist1", "Artist2"
			};

			IArtistsRepository repos = MockRepository.CreateMockRepository("Pop", artists);
			ArtistBinder binder = new ArtistBinder(repos);

			ModelBindingContext ctx = BinderHelpers.CreateModelBindingContext("artist", "plibble");

			// Act
			IArtist a = binder.BindModel(null, ctx) as IArtist;

			// Assert
			Assert.AreEqual(null, a);
			Assert.AreEqual(false, ctx.ModelState.IsValid);
			Assert.AreEqual(1, ctx.ModelState["artist"].Errors.Count);
		}
	}
}
