using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public class ExportModelStateToTempData : ExportToTempDataFilter
	{
		public ExportModelStateToTempData(string a_key) : base(a_key, EExportWhen.ModelStateInvalid) { }

		protected override object GetModel(ControllerBase a_controller)
		{
			return a_controller.ViewData.ModelState;
		}
	}
}
