using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using Triggerfish.Testing.Web.Mvc;
using MvcTemplate.Model;
using MvcTemplate.Web;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class InboundRoutingTests
	{
		// all route data is forced into lower-case by the routing framework
		// Triggerfish.Web.Routing.FriendlyUrlRoute

		[TestMethod]
		public void RootIsHome()
		{
			MvcAssert.IsInboundRouteCorrect(new	{
					controller = "Home",
					action = "Index"
				}, 
				"~/", 
				MvcApplication.RegisterRoutes
			);
		}

		[TestMethod]
		public void ShouldDecodeGenreUrl()
		{
			IGenre g = MockGenre.CreateMockGenre("hip hop"); // need to be lower-case as this is how the urls are decoded
			MvcAssert.IsInboundRouteCorrect(g.Route(), "~/genre/hip-hop", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldDecodeArtistUrl()
		{
			IArtist a = MockArtist.CreateMockArtist(2, "crosby stills and nash"); // need to be lower-case as this is how the urls are decoded
			MvcAssert.IsInboundRouteCorrect(a.Route(), "~/artists/crosby-stills-and-Nash", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void SlashSearchIsSearchHome()
		{
			MvcAssert.IsInboundRouteCorrect(new	{
					controller = "Search",
					action = "Index"
				},
				"~/search",
				MvcApplication.RegisterRoutes
			);
		}

		[TestMethod]
		public void SlashControllerSlashActionIsValid()
		{
			MvcAssert.IsInboundRouteCorrect(new	{
					controller = "Abc",
					action = "123"
				},
				"~/abc/123",
				MvcApplication.RegisterRoutes
			);
		}
	}
}
