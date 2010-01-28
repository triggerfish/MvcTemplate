using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using MvcTemplate.Model;

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
			return Triggerfish.Web.Mvc.Testing.UrlHelpers.SanitiseUrl(a_url, MvcApplication.RegisterRoutes, a_allowAuthoriseAttributeOnAction);
		}
	}
}
