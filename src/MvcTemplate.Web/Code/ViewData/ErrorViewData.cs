using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Web
{
	public class ErrorViewData : ViewData
	{
		public Exception Exception { get; set; }

		public ErrorViewData(Exception a_ex)
		{
			Exception = a_ex;
		}
	}
}
