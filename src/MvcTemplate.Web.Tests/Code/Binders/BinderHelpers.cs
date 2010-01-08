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
		public static ModelBindingContext CreateModelBindingContext(string a_argName, string a_argValue)
		{
			ModelBindingContext ctx = new ModelBindingContext();
			ctx.ModelName = a_argName;
			ctx.ModelState = new ModelStateDictionary();
			ctx.ValueProvider = new Dictionary<string, ValueProviderResult>();
			ctx.ValueProvider.Add(a_argName, new ValueProviderResult(a_argValue, a_argValue, CultureInfo.CurrentCulture));
			return ctx;
		}

		public static ModelBindingContext CreateModelBindingContext(string a_argName, IDictionary<string, string> a_argValues)
		{
			ModelBindingContext ctx = new ModelBindingContext();
			ctx.ModelName = a_argName;
			ctx.ModelState = new ModelStateDictionary();
			ctx.ValueProvider = new Dictionary<string, ValueProviderResult>();
			foreach (KeyValuePair<string, string> kvp in a_argValues)
			{
				ctx.ValueProvider.Add(kvp.Key, new ValueProviderResult(kvp.Value, kvp.Value, CultureInfo.CurrentCulture));
			}
			return ctx;
		}
	}
}
