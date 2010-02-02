using System;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IClientSideValidationArgs { }

	public interface IClientSideValidation
	{
		string GetValidationData(IClientSideValidationArgs args);
	}
}
