using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public static class ControllerExtensions
	{
		public static RedirectResult SanitisedRedirect(this Controller a_controller, string a_url)
		{
			return a_controller.SanitisedRedirect(a_url, true);
		}
	
		public static RedirectResult SanitisedRedirect(this Controller a_controller, string a_url, bool a_allowAuthoriseAttributeOnAction)
		{
			return new RedirectResult(RouteHelpers.SanitiseUrl(a_url, a_allowAuthoriseAttributeOnAction));
		}
	}
}
