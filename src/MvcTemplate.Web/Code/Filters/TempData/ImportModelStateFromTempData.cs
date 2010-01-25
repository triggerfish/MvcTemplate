using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public class ImportModelStateFromTempData : ImportFromTempDataFilter
	{
		public ImportModelStateFromTempData(string a_key) : base(a_key, typeof(ModelStateDictionary)) { }

		protected override void SetModel(object a_model, ControllerBase a_controller)
		{
			a_controller.ViewData.ModelState.Merge(a_model as ModelStateDictionary);
		}
	}
}
