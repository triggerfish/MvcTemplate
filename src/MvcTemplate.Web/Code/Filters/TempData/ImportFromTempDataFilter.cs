using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public abstract class ImportFromTempDataFilter : TempDataFilter
	{
		protected Type ModelType { get; private set; }

		protected ImportFromTempDataFilter(string a_key, Type a_modelType)
			: base(a_key)
		{
			ModelType = a_modelType;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			object model = filterContext.Controller.TempData[Key];

			if (model != null && model.GetType() == ModelType)
			{
				SetModel(model, filterContext.Controller);
			}
			else
			{
				filterContext.Controller.TempData.Remove(Key);
			}

			base.OnActionExecuting(filterContext);
		}

		protected abstract void SetModel(object a_model, ControllerBase a_controller);
	}
}
