using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public abstract class ModelBinder<T> : IModelBinder where T : class
	{
		// data
		//

		private ModelBindingContext m_context;

		// properties
		//

		protected string ModelName { get { return m_context.ModelName; } }

		// constructors
		//

		protected ModelBinder()
		{
		}

		// public methods
		//

		public object BindModel(ControllerContext a_controllerContext, ModelBindingContext a_bindingContext)
		{
			// The action method argument
			m_context = a_bindingContext;

			try
			{
				object obj = Bind();

				if (null != obj)
				{
					Validate(obj);
				}

				return obj;
			}
			catch (ValidationException ex)
			{
				ex.ToModelErrors(a_bindingContext.ModelState, "");
			}

			return null;
		}

		// protected methods
		//

		protected abstract object Bind();

		protected virtual void Validate(object a_object)
		{
			IValidator validator = ObjectFactory.TryGet<IValidator>();
			if (null != validator)
			{
				validator.Validate(a_object);
			}
		}

		protected string GetValue(string a_key, bool a_mustHaveValue)
		{
			ValueProviderResult v;

			// first try with the prefix
			string key = m_context.ModelName + "." + a_key;
			bool gotIt = m_context.ValueProvider.TryGetValue(key, out v);

			// if that failed, try with the raw name (unless the model has the Bind(Prefix = XXX) attribute specified)
			if (!gotIt && m_context.FallbackToEmptyPrefix)
			{
				key = a_key;
				gotIt = m_context.ValueProvider.TryGetValue(key, out v);
			}

			if (gotIt)
			{
				m_context.ModelState.SetModelValue(key, v);

				if (!a_mustHaveValue || !String.IsNullOrEmpty(v.AttemptedValue))
				{
					return v.AttemptedValue;
				}
			}

			if (a_mustHaveValue)
			{
				throw new ValidationException(key, String.Format("{0} must be specified", a_key));
			}

			return null;
		}
	}
}
