using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Triggerfish.Ninject;

namespace MvcTemplate.Web
{
	public class NavBarLinkGeneratorAttribute : ActionFilterAttribute
	{
		public Type Generator { get; set; }

		public NavBarLinkGeneratorAttribute()
		{
		}

		public NavBarLinkGeneratorAttribute(Type generator)
		{
			Generator = generator;
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			object model = filterContext.Controller.ViewData.Model;

			if (null != model && model is ViewData)
			{
				((ViewData)model).NavBarWidget = new NavBarWidget(ObjectFactory.TryGet<IHyperlinkGenerator>(Generator));
			}

			base.OnActionExecuted(filterContext);
		}
	}
}
