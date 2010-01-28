using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;
using Triggerfish.Validator;
using Triggerfish.Ninject;

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

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			// The action method argument
			m_context = bindingContext;

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
				ex.ToModelErrors(bindingContext.ModelState, "");
			}

			return null;
		}

		// protected methods
		//

		protected abstract object Bind();

		protected virtual void Validate(object obj)
		{
			IValidator validator = ObjectFactory.TryGet<IValidator>();
			if (null != validator)
			{
				validator.Validate(obj);
			}
		}

		protected string GetValue(string key, bool mustHaveValue)
		{
			ValueProviderResult v;

			// first try with the prefix
			string k = m_context.ModelName + "." + key;
			bool gotIt = m_context.ValueProvider.TryGetValue(k, out v);

			// if that failed, try with the raw name (unless the model has the Bind(Prefix = XXX) attribute specified)
			if (!gotIt && m_context.FallbackToEmptyPrefix)
			{
				k = key;
				gotIt = m_context.ValueProvider.TryGetValue(k, out v);
			}

			if (gotIt)
			{
				m_context.ModelState.SetModelValue(k, v);

				if (!mustHaveValue || !String.IsNullOrEmpty(v.AttemptedValue))
				{
					return v.AttemptedValue;
				}
			}

			if (mustHaveValue)
			{
				throw new ValidationException(key, String.Format("{0} must be specified", key));
			}

			return null;
		}
	}
}
