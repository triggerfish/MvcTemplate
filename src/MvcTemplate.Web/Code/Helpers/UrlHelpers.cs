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
		public static string SanitiseUrl(string url)
		{
			return SanitiseUrl(url, true);
		}

		public static string SanitiseUrl(string url, bool allowAuthoriseAttributeOnAction)
		{
			return Triggerfish.Web.Mvc.Testing.UrlHelpers.SanitiseUrl(url, MvcApplication.RegisterRoutes, allowAuthoriseAttributeOnAction);
		}
	}
}
