using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using Triggerfish.Web.Mvc.Testing;
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
		public void ShouldResolveHomeRoute()
		{
			MvcAssert.IsInboundRouteValid(RouteHelpers.HomeRoute(), "~/", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSearchRoute()
		{
			MvcAssert.IsInboundRouteValid(RouteHelpers.SearchRoute(), "~/search", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSearchResultsRoute()
		{
			MvcAssert.IsInboundRouteValid(RouteHelpers.SearchResultsRoute(), "~/search-results", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveRegisterRoute()
		{
			MvcAssert.IsInboundRouteValid(RouteHelpers.RegisterRoute(null), "~/register", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveLoginRoute()
		{
			MvcAssert.IsInboundRouteValid(RouteHelpers.LoginRoute(null), "~/login", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveLogoutRoute()
		{
			MvcAssert.IsInboundRouteValid(RouteHelpers.LogoutRoute(null), "~/logout", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveGenreRoute()
		{
			IGenre g = MockGenre.CreateMockGenre("hip hop"); // need to be lower-case as this is how the urls are decoded
			MvcAssert.IsInboundRouteValid(RouteHelpers.GenreRoute(g), "~/genre/hip-hop", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveAllArtistsRoute()
		{
			MvcAssert.IsInboundRouteValid(RouteHelpers.AllArtistsRoute(), "~/artists", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveArtistRoute()
		{
			IArtist a = MockArtist.CreateMockArtist(2, "crosby stills and nash"); // need to be lower-case as this is how the urls are decoded
			MvcAssert.IsInboundRouteValid(RouteHelpers.ArtistRoute(a), "~/artist/crosby-stills-and-nash", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSecretRoute()
		{
			MvcAssert.IsInboundRouteValid(RouteHelpers.SecretRoute(), "~/secret", MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void SlashControllerSlashActionIsInvalid()
		{
			try
			{
				MvcAssert.IsInboundRouteValid(new {
					controller = "Abc",
					action = "123"
				},
					"~/abc/123",
					MvcApplication.RegisterRoutes
				);
			}
			catch (AssertFailedException)
			{
				// expected
				return;
			}

			Assert.Fail("The default controller/action route should be disabled");
		}
	}
}
