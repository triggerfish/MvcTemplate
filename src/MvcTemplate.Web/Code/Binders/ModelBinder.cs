using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class ModelBinderException : Exception
	{
		public string Key { get; private set; } 

		public ModelBinderException() : base() { }

		public ModelBinderException(string a_key)
			: base()
		{
			Key = a_key;
		}

		public ModelBinderException(string a_key, string a_message)
			: base(a_message)
		{
			Key = a_key;
		}
	
		public ModelBinderException(string a_key, string a_message, Exception a_inner)
			: base(a_message, a_inner)
		{
			Key = a_key;
		}
	}

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
				return Bind();
			}
			catch (ModelBinderException ex)
			{
				a_bindingContext.ModelState.AddModelError(ex.Key, ex.Message);
			}

			return null;
		}

		// protected methods
		//

		protected abstract object Bind();

		protected string GetValue(string a_key, bool a_valueMustExist)
		{
			ValueProviderResult v;
			if (m_context.ValueProvider.TryGetValue(a_key, out v))
			{
				m_context.ModelState.SetModelValue(a_key, v);

				if (!a_valueMustExist || !String.IsNullOrEmpty(v.AttemptedValue))
				{
					return v.AttemptedValue;
				}
			}

			if (a_valueMustExist)
			{
				throw new ModelBinderException(a_key, String.Format("{0} must be specified", a_key));
			}

			return null;
		}
	}
}
