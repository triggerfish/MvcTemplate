using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Globalization;

namespace MvcTemplate.Web.Tests
{
	public static class BinderHelpers
	{
		public static ModelBindingContext CreateModelBindingContext(string a_key, string a_value)
		{
			ModelBindingContext ctx = new ModelBindingContext();
			ctx.ModelName = a_key;
			ctx.ModelState = new ModelStateDictionary();
			ctx.ValueProvider = new Dictionary<string, ValueProviderResult>();
			ctx.ValueProvider.Add(a_key, new ValueProviderResult(a_value, a_value, CultureInfo.CurrentCulture));
			return ctx;
		}
	}
}
