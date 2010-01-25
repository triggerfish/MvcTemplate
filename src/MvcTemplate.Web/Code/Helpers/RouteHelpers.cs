using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using MvcTemplate.Model;
using Triggerfish.Testing.Web.Mvc;

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

		public static RouteValueDictionary SearchResultsRoute()
		{
			return new RouteValueDictionary(new { controller = "Search", action = "Results" });
		}

		public static RouteValueDictionary RegisterRoute(string a_returnUrl)
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Register" }).AddReturnUrl(a_returnUrl);
		}

		public static RouteValueDictionary LoginRoute(string a_returnUrl)
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Login" }).AddReturnUrl(a_returnUrl);
		}

		public static RouteValueDictionary LogoutRoute(string a_returnUrl)
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Logout" }).AddReturnUrl(a_returnUrl);
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
		public static RouteValueDictionary SecretRoute()
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Secret" });
		}
	}
}
