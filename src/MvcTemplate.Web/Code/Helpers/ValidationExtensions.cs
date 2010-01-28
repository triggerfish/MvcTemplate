using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;
using System.Web.Mvc;
using Triggerfish.Validator;

namespace MvcTemplate.Web
{
	public static class ValidationExtensions
	{
		public static void ToModelErrors(this ValidationException exception, ModelStateDictionary dictionary, string prefix)
		{
			if (!String.IsNullOrEmpty(prefix))
			{
				prefix = prefix + ".";
			}

			foreach (string key in exception.Errors)
			{
				foreach (string value in exception.Errors.GetValues(key))
				{
					dictionary.AddModelError(prefix + key, value);
				}
			}
		}
	}
}
