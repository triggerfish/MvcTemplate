using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public static class UrlExtensions
	{
		public static string Stylesheet(this UrlHelper helper, string filename)
		{
			return helper.Content(String.Format("~/content/styles/{0}", filename));
		}

		public static string Script(this UrlHelper helper, string filename)
		{
			return helper.Content(String.Format("~/content/scripts/{0}", filename));
		}
		
		public static string Image(this UrlHelper helper, string filename)
		{
			return helper.Content(String.Format("~/content/images/{0}", filename));
		}
	}
}
