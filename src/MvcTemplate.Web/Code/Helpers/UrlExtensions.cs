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
		public static string Stylesheet(this UrlHelper a_helper, string a_filename)
		{
			return a_helper.Content(String.Format("~/content/styles/{0}", a_filename));
		}

		public static string Script(this UrlHelper a_helper, string a_filename)
		{
			return a_helper.Content(String.Format("~/content/script/{0}", a_filename));
		}
		
		public static string Image(this UrlHelper a_helper, string a_filename)
		{
			return a_helper.Content(String.Format("~/content/images/{0}", a_filename));
		}
	}
}
