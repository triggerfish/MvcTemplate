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
		public static RouteValueDictionary HomeRoute()
		{
			return new RouteValueDictionary(new { controller = "Home", action = "Index" });
		}

		public static RouteValueDictionary SearchRoute()
		{
			return new RouteValueDictionary(new { controller = "Search", action = "Index" });
		}

		public static RouteValueDictionary RegisterRoute()
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Register" });
		}

		public static RouteValueDictionary LoginRoute()
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Login" });
		}

		public static RouteValueDictionary LogoutRoute()
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Logout" });
		}

		public static RouteValueDictionary GenreRoute(IGenre a_genre)
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Genre", genre = a_genre.Name });
		}

		public static RouteValueDictionary AllArtistsRoute()
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Index" });
		}

		public static RouteValueDictionary ArtistRoute(IArtist a_artist)
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Artist", artist = a_artist.Name });
		}
	}
}
