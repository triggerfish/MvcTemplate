using System;
using System.Text;

namespace MvcTemplate.Model
{
	public class xValClientSideValidationArgs : IClientSideValidationArgs
	{
		public string ElementPrefix { get; set; }
		public Type DataType { get; set; }
		public bool UseIoCToResolveType { get; set; }

		public xValClientSideValidationArgs()
		{
			UseIoCToResolveType = true;
		}
	}
}
