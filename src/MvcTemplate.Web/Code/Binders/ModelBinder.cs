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
	public abstract class ModelBinder<T> : Triggerfish.Web.Mvc.ModelBinder<T> where T : class
	{
		private IValidator m_validator;

		protected ModelBinder(IValidator validator)
		{
			m_validator = validator;
		}

		protected override void Validate(object obj)
		{
			if (null != m_validator)
			{
				m_validator.Validate(obj);
			}
		}
	}
}
