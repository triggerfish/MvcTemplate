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
		public static ModelBindingContext CreateModelBindingContext(string a_argName)
		{
			return new ModelBindingContext() {
				FallbackToEmptyPrefix = true,
				ModelName = a_argName,
				ModelState = new ModelStateDictionary(),
				ValueProvider = new Dictionary<string, ValueProviderResult>(),
			};
		}

		public static ModelBindingContext CreateModelBindingContext(string a_argName, string a_argValue)
		{
			ModelBindingContext ctx = CreateModelBindingContext(a_argName);
			ctx.ValueProvider.Add(a_argName, new ValueProviderResult(a_argValue, a_argValue, CultureInfo.CurrentCulture));
			return ctx;
		}

		public static ModelBindingContext CreateModelBindingContext(string a_argName, IDictionary<string, string> a_argValues)
		{
			ModelBindingContext ctx = CreateModelBindingContext(a_argName);
			foreach (KeyValuePair<string, string> kvp in a_argValues)
			{
				ctx.ValueProvider.Add(kvp.Key, new ValueProviderResult(kvp.Value, kvp.Value, CultureInfo.CurrentCulture));
			}
			return ctx;
		}
	}
}
