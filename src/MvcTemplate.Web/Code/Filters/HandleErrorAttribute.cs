using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public class HandleErrorAttribute : System.Web.Mvc.HandleErrorAttribute
	{
		public override void OnException(ExceptionContext filterContext)
		{
			base.OnException(filterContext);

			ViewResult vr = filterContext.Result as ViewResult;
			if (null != vr)
			{
				HandleErrorInfo model = vr.ViewData.Model as HandleErrorInfo;
				vr.ViewData = new ViewDataDictionary<ErrorViewData>(new ErrorViewData(model));
			}
		}
	}
}
