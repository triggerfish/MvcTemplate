using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Triggerfish.Web.Routing;
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

		public static RouteValueDictionary SearchResultsRoute()
		{
			return new RouteValueDictionary(new { controller = "Search", action = "Results" });
		}

		public static RouteValueDictionary RegisterRoute(string returnUrl)
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Register" }).AddReturnUrl(returnUrl);
		}

		public static RouteValueDictionary LoginRoute(string returnUrl)
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Login" }).AddReturnUrl(returnUrl);
		}

		public static RouteValueDictionary LogoutRoute(string returnUrl)
		{
			return new RouteValueDictionary(new { controller = "Account", action = "Logout" }).AddReturnUrl(returnUrl);
		}

		public static RouteValueDictionary GenreRoute(IGenre genre)
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Genre", genre = genre.Name });
		}

		public static RouteValueDictionary AllArtistsRoute()
		{
			return AllArtistsRoute(1);
		}

		public static RouteValueDictionary AllArtistsRoute(int page)
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "AllArtists", page = page });
		}

		public static RouteValueDictionary ArtistRoute(IArtist artist)
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Artist", artist = artist.Name });
		}
		public static RouteValueDictionary SecretRoute()
		{
			return new RouteValueDictionary(new { controller = "Artists", action = "Secret" });
		}
	}
}
