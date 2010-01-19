using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcTemplate.Model;
using NHibernate.Validator.Engine;

namespace MvcTemplate.Database
{
	public class Validator : MvcTemplate.Model.IValidator
	{
		private ValidatorEngine m_engine;

		public Validator(ValidatorEngine a_engine)
		{
			m_engine = a_engine;
		}

		public void Validate(object a_object)
		{
			InvalidValue[] errors = m_engine.Validate(a_object);
			if (null != errors && errors.Length > 0)
			{
				ValidationException ex = new ValidationException();

				foreach (InvalidValue val in errors)
				{
					ex.Errors.Add(val.PropertyName, val.Message);
				}

				throw ex;
			}
		}
	}
}
