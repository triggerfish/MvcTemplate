using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MvcTemplate.Web
{
	public static class RouteValueDictionaryExtensions
	{
		public static RouteValueDictionary AddReturnUrl(this RouteValueDictionary a_route, Uri a_uri)
		{
			if (null != a_uri && !String.IsNullOrEmpty(a_uri.PathAndQuery))
			{
				a_route.Add("returnUrl", a_uri.PathAndQuery);
			}
			return a_route;
		}
	}
}
