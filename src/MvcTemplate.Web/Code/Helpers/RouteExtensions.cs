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
		public static RouteValueDictionary Route(this IArtist artist)
		{
			return RouteHelpers.ArtistRoute(artist);
		}

		public static RouteValueDictionary Route(this IGenre genre)
		{
			return RouteHelpers.GenreRoute(genre);
		}
	}
}
