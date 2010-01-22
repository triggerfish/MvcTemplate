using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public class ExportModelToTempData : ExportToTempDataFilter
	{
		public Type ModelType { get; private set; }

		public ExportModelToTempData(string a_key, Type a_modelType)
			: base(a_key, EExportWhen.ModelStateValid)
		{
			ModelType = a_modelType;
		}

		protected override object GetModel(ControllerBase a_controller)
		{
			object model = a_controller.ViewData.Model;
			if (null != model && model.GetType() == ModelType)
			{
				return model;
			}
			return null;
		}
	}
}
