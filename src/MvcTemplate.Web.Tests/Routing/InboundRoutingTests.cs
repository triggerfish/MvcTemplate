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
	public class InboundRoutingTests
	{
		[TestMethod]
		public void RootIsHome()
		{
			TestRoute("~/",
				new RouteValueDictionary( new {
					controller = "Home",
					action = "Index"
				})
			);
		}

		[TestMethod]
		public void ShouldDecodeGenreUrl()
		{
			IGenre g = MockGenre.CreateMockGenre("hip hop"); // need to be lower-case as this is how the urls are decoded
			TestRoute("~/genre/hip-hop", g.Route());
		}

		[TestMethod]
		public void ShouldDecodeArtistUrl()
		{
			IArtist a = MockArtist.CreateMockArtist(2, "crosby stills and nash"); // need to be lower-case as this is how the urls are decoded
			TestRoute("~/artists/crosby-stills-and-Nash", a.Route());
		}

		[TestMethod]
		public void SlashSearchIsSearchHome()
		{
			TestRoute("~/search",
				new RouteValueDictionary( new {
					controller = "Search",
					action = "Index"
				})
			);
		}

		[TestMethod]
		public void SlashControllerSlashActionIsValid()
		{
			// the case of the url is always forced to lowercase
			// (using Triggerfish.Web.Mvc) and so the parsed
			// controller and action names are lowercase also
			TestRoute("~/cont/Act",
				new RouteValueDictionary(new
				{
					controller = "cont",
					action = "act"
				})
			);
		}

		private void TestRoute(string a_url, RouteValueDictionary a_route)
		{
			// Arrange: Prepare the route collection and a mock request context
			RouteCollection routes = new RouteCollection();
			MvcApplication.RegisterRoutes(routes);

			var mockHttpContext = MockHttp.MakeMockHttpContext(a_url);

			// Act: Get the mapped route
			RouteData routeData = routes.GetRouteData(mockHttpContext.Object);

			// Assert: Test the route values against expectations
			Assert.IsNotNull(routeData);
			foreach (var expectedVal in a_route)
			{
				if (expectedVal.Value == null)
				{
					Assert.IsNull(routeData.Values[expectedVal.Key]);
				}
				else
				{
					Assert.AreEqual(expectedVal.Value.ToString(),
					routeData.Values[expectedVal.Key].ToString());
				}
			}
		}
	}
}
