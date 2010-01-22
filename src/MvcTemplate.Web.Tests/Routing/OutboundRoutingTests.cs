using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triggerfish.Testing.Web.Mvc;
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
			MvcAssert.IsOutboundRouteCorrect("/", RouteHelpers.HomeRoute(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSearchRoute()
		{
			MvcAssert.IsOutboundRouteCorrect("/search", RouteHelpers.SearchRoute(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSearchResultsRoute()
		{
			MvcAssert.IsOutboundRouteCorrect("/search-results", RouteHelpers.SearchResultsRoute(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveRegisterRoute()
		{
			MvcAssert.IsOutboundRouteCorrect("/register", RouteHelpers.RegisterRoute(null), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveLoginRoute()
		{
			MvcAssert.IsOutboundRouteCorrect("/login", RouteHelpers.LoginRoute(null), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveLogoutRoute()
		{
			MvcAssert.IsOutboundRouteCorrect("/logout", RouteHelpers.LogoutRoute(null), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveGenreRoute()
		{
			IGenre g = MockGenre.CreateMockGenre("Hip Hop");
			MvcAssert.IsOutboundRouteCorrect("/genre/hip-hop", RouteHelpers.GenreRoute(g), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveAllArtistsRoute()
		{
			MvcAssert.IsOutboundRouteCorrect("/artists", RouteHelpers.AllArtistsRoute(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveArtistRoute()
		{
			IArtist a = MockArtist.CreateMockArtist(3, "Crosby Stills And Nash");
			MvcAssert.IsOutboundRouteCorrect("/artists/crosby-stills-and-nash", RouteHelpers.ArtistRoute(a), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldResolveSecretRoute()
		{
			MvcAssert.IsOutboundRouteCorrect("/secret", RouteHelpers.SecretRoute(), MvcApplication.RegisterRoutes);
		}
	}
}
