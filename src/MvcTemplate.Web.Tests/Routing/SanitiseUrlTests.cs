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
	public class SanitiseUrlTests
	{
		[TestMethod]
		public void ShouldSanitiseValidRoute()
		{
			Assert.AreEqual("/artists", RouteHelpers.SanitiseUrl("/artists", true));
		}
	
		[TestMethod]
		public void ShouldSanitiseInvalidRoute()
		{
			Assert.AreEqual("/", RouteHelpers.SanitiseUrl("/invalid", true));
		}

		[TestMethod]
		public void ShouldSanitiseRouteRequiringAuthorisation1()
		{
			Assert.AreEqual("/secret", RouteHelpers.SanitiseUrl("/secret", true));
		}

		[TestMethod]
		public void ShouldSanitiseRouteRequiringAuthorisation2()
		{
			Assert.AreEqual("/", RouteHelpers.SanitiseUrl("/secret", false));
		}
	}
}
