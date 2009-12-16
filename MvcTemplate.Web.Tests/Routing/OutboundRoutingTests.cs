using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
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
			Assert.IsTrue(MockHttp.IsValidOutboundUrl(g.Route(), "/genre/hip-hop"));
		}

		[TestMethod]
		public void ShouldEncodeArtistUrl()
		{
			IArtist a = MockArtist.CreateMockArtist(3, "Crosby Stills And Nash");
			Assert.IsTrue(MockHttp.IsValidOutboundUrl(a.Route(), "/artists/crosby-stills-and-nash"));
		}
	}
}
