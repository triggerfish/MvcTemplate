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
			RouteValueDictionary r = new RouteValueDictionary(new { controller = "Artists", action = "Artist", name = a_artist.Name });
			return r;
		}

		public static RouteValueDictionary Route(this IGenre a_genre)
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Genre", name = a_genre.Name });
		}
	}
}
