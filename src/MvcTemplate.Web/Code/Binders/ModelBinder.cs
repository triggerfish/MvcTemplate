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
		protected override void Validate(object obj)
		{
			IValidator validator = ObjectFactory.TryGet<IValidator>();
			if (null != validator)
			{
				validator.Validate(obj);
			}
		}
	}
}
