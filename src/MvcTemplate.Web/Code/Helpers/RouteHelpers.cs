using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public static class RouteHelpers
	{
		public static RouteValueDictionary AllGenreRoute()
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Genre", name = "all" });
		}
	}
}
