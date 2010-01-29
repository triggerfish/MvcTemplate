using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public class IsAuthenticatedAttribute : ActionFilterAttribute
	{
		public string RedirectUrl { get; set; }

		public IsAuthenticatedAttribute()
		{
			RedirectUrl = "/"; // default home
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);

			if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
				filterContext.Result = new RedirectResult(RedirectUrl);
			}
		}
	}
}
