using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using MvcTemplate.Model;
using Triggerfish.Testing.Web.Mvc;

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

		public static string SanitiseUrl(this RouteInformation a_routeInfo, bool a_allowAuthoriseAttributeOnAction)
		{
			if (a_routeInfo.Valid && (a_allowAuthoriseAttributeOnAction || !a_routeInfo.DoesActionRequireAuthorisation("MvcTemplate.Web.Controllers", "MvcTemplate.Web")))
			{
				return a_routeInfo.Url;
			}

			return "/"; // return home url by default
		}
	}
}
