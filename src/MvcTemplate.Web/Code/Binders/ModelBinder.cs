using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public abstract class ModelBinder : DefaultModelBinder
	{
		protected IRepository Repository { get;	private set; }

		protected ModelBinder(IRepository a_repository)
		{
			Repository = a_repository;
		}

		public override object BindModel(ControllerContext a_controllerContext, ModelBindingContext a_bindingContext)
		{
			// The action method argument
			string key = a_bindingContext.ModelName;

			ValueProviderResult value = a_bindingContext.ValueProvider[key];

			if ((value != null) && !string.IsNullOrEmpty(value.AttemptedValue))
			{
				// Follow convention by stashing attempted value in ModelState
				a_bindingContext.ModelState.SetModelValue(key, value);

				try
				{
					return BindValue(value.AttemptedValue);
				}
				catch (Exception ex)
				{
					a_bindingContext.ModelState.AddModelError(key, ex);
				}
			}

			return null;
		}

		protected abstract object BindValue(string a_value);
	}
}
