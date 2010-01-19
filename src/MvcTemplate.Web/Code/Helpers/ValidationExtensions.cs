using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public static class ValidationExtensions
	{
		public static void ToModelErrors(this ValidationException a_exception, ModelStateDictionary a_dictionary, string a_prefix)
		{
			if (!String.IsNullOrEmpty(a_prefix))
			{
				a_prefix = a_prefix + ".";
			}

			foreach (string key in a_exception.Errors)
			{
				foreach (string value in a_exception.Errors.GetValues(key))
				{
					a_dictionary.AddModelError(a_prefix + key, value);
				}
			}
		}
	}
}
