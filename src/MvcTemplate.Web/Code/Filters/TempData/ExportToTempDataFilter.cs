using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public abstract class ExportToTempDataFilter : TempDataFilter
	{
		protected enum EExportWhen
		{
			ModelStateValid,
			ModelStateInvalid
		}
		
		protected EExportWhen ExportWhen { get; private set; }

		protected ExportToTempDataFilter(string a_key, EExportWhen a_when)
			: base(a_key)
		{
			ExportWhen = a_when;
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			bool valid = filterContext.Controller.ViewData.ModelState.IsValid;
			// only export when ModelState is valid
			if (ExportWhen == EExportWhen.ModelStateValid && valid ||
				ExportWhen == EExportWhen.ModelStateInvalid && !valid)
			{
				// export if we are redirecting
				if ((filterContext.Result is RedirectResult) || (filterContext.Result is RedirectToRouteResult))
				{
					filterContext.Controller.TempData[Key] = GetModel(filterContext.Controller);
				}
			}

			base.OnActionExecuted(filterContext);
		}

		protected abstract object GetModel(ControllerBase a_controller);
	}
}
