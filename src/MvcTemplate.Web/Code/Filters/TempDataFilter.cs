using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web
{
	public abstract class TempDataFilter : ActionFilterAttribute
	{
		protected string Key { get; private set; }

		protected TempDataFilter(string a_key)
		{
			Key = a_key;
		}
	}
}
