using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using MvcTemplate.Model;
using Triggerfish.Testing.Web.Mvc;

namespace MvcTemplate.Web
{
	public static class UrlHelpers
	{
		public static string SanitiseUrl(string a_url)
		{
			return SanitiseUrl(a_url, true);
		}

		public static string SanitiseUrl(string a_url, bool a_allowAuthoriseAttributeOnAction)
		{
			return RouteInformation.Create(a_url, MvcApplication.RegisterRoutes).SanitiseUrl(a_allowAuthoriseAttributeOnAction);
		}
	}
}
