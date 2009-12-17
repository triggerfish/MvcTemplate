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
		public void ShouldEncodeGenreUrl()
		{
			IGenre g = MockGenre.CreateMockGenre("Hip Hop");
			MvcAssert.IsOutboundRouteCorrect("/genre/hip-hop", g.Route(), MvcApplication.RegisterRoutes);
		}

		[TestMethod]
		public void ShouldEncodeArtistUrl()
		{
			IArtist a = MockArtist.CreateMockArtist(3, "Crosby Stills And Nash");
			MvcAssert.IsOutboundRouteCorrect("/artists/crosby-stills-and-nash", a.Route(), MvcApplication.RegisterRoutes);
		}
	}
}
