using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MvcTemplate.Web
{
	public static class RouteValueDictionaryExtensions
	{
		public static RouteValueDictionary AddReturnUrl(this RouteValueDictionary a_route, string a_url)
		{
			if (null != a_url && !String.IsNullOrEmpty(a_url))// && a_url != "/")
			{
				a_route.Add("returnUrl", a_url);
			}
			return a_route;
		}
	}
}
