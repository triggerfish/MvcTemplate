using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triggerfish.Web.Mvc.Testing;
using MvcTemplate.Model;
using MvcTemplate.Web;

namespace MvcTemplate.Web.Tests
{
	[TestClass]
	public class OutboundRoutingTests
	{
		[TestMethod]
		public void ShouldResolveHomeRoute()
		{
			MvcAssert.IsOutboundRouteValid("/", RouteHelpers.HomeRoute(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSearchRoute()
		{
			MvcAssert.IsOutboundRouteValid("/search", RouteHelpers.SearchRoute(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSearchResultsRoute()
		{
			MvcAssert.IsOutboundRouteValid("/search-results", RouteHelpers.SearchResultsRoute(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveRegisterRoute()
		{
			MvcAssert.IsOutboundRouteValid("/register", RouteHelpers.RegisterRoute(null), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveLoginRoute()
		{
			MvcAssert.IsOutboundRouteValid("/login", RouteHelpers.LoginRoute(null), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveLogoutRoute()
		{
			MvcAssert.IsOutboundRouteValid("/logout", RouteHelpers.LogoutRoute(null), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveGenreRoute()
		{
			IGenre g = MockGenre.CreateMockGenre("Hip Hop");
			MvcAssert.IsOutboundRouteValid("/genre/hip-hop", RouteHelpers.GenreRoute(g), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveAllArtistsRoute()
		{
			MvcAssert.IsOutboundRouteValid("/artists", RouteHelpers.AllArtistsRoute(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveArtistRoute()
		{
			IArtist a = MockArtist.CreateMockArtist(3, "Crosby Stills And Nash");
			MvcAssert.IsOutboundRouteValid("/artist/crosby-stills-and-nash", RouteHelpers.ArtistRoute(a), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSecretRoute()
		{
			MvcAssert.IsOutboundRouteValid("/secret", RouteHelpers.SecretRoute(), MvcApplication.RegisterRoutes);
		}
	}
}
