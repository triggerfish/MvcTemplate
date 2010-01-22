using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public class ImportModelFromTempData : ImportFromTempDataFilter
	{
		public ImportModelFromTempData(string a_key, Type a_modelType)
			: base(a_key, a_modelType)
		{
		}

		protected override void SetModel(object a_model, ControllerBase a_controller)
		{
			a_controller.ViewData.Model = a_model;
		}
	}
}
