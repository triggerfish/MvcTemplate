using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public class ErrorViewData : ViewData
	{
		public HandleErrorInfo ErrorInfo { get; private set; }
		public Exception Exception
		{
			get
			{
				if (null != ErrorInfo)
					return ErrorInfo.Exception;
				return new Exception();
			}
		}

		public ErrorViewData(HandleErrorInfo info)
		{
			ErrorInfo = info;
		}
	}
}
