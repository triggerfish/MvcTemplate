using System;
using System.Text;
using xVal;
using xVal.Html;
using MvcTemplate.Model;
using Triggerfish.Ninject;

namespace MvcTemplate.Model
{
	public class xValClientSideValidation : IClientSideValidation
	{
		public string GetValidationData(IClientSideValidationArgs args)
		{
			xValClientSideValidationArgs xValArgs = args as xValClientSideValidationArgs;

			Type t = xValArgs.DataType;

			if (xValArgs.UseIoCToResolveType)
			{
				object o = ObjectFactory.TryGet<object>(t);
				if (null != o)
				{
					t = o.GetType();
				}
			}

			ValidationInfo vi = new ValidationInfo(ActiveRuleProviders.GetRulesForType(t), xValArgs.ElementPrefix);
			return vi.ToString();
		}
	}
}
