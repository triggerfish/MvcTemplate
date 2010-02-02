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
	public class GenreBinderTests
	{
		[TestMethod]
		public void ShouldBindGenre()
		{
			// Arrange
			IArtistsRepository repos = MockArtistsRepository.CreateMockRepository("Pop", null);
			GenreBinder binder = new GenreBinder(repos);

			ModelBindingContext ctx = BinderHelpers.CreateModelBindingContext("genre", "pop");
			
			// Act
			IGenre g = binder.BindModel(null, ctx) as IGenre;

			// Assert
			Assert.AreNotEqual(null, g);
			Assert.AreEqual(true, ctx.ModelState.IsValid);
			Assert.AreEqual(0, g.Id);
			Assert.AreEqual("Pop", g.Name);
		}

		[TestMethod]
		public void ShouldFailToBindGenre()
		{
			// Arrange
			IArtistsRepository repos = MockArtistsRepository.CreateMockRepository("Pop", null);
			GenreBinder binder = new GenreBinder(repos);

			ModelBindingContext ctx = BinderHelpers.CreateModelBindingContext("genre", "plibble");

			// Act
			IGenre g = binder.BindModel(null, ctx) as IGenre;

			// Assert
			Assert.AreEqual(null, g);
			Assert.AreEqual(false, ctx.ModelState.IsValid);
			Assert.AreEqual(1, ctx.ModelState["genre"].Errors.Count);
		}
	}
}
