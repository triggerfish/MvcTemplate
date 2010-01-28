using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public static class RouteExtensions
	{
		public static RouteValueDictionary Route(this IArtist a_artist)
		{
			return RouteHelpers.ArtistRoute(a_artist);
		}

		public static RouteValueDictionary Route(this IGenre a_genre)
		{
			return RouteHelpers.GenreRoute(a_genre);
		}
	}
}
