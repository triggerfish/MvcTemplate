using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;
using Triggerfish.Web.Mvc.Testing;

namespace MvcTemplate.Web
{
	public class AccountViewData : ViewData
	{
		public string ReturnUrl { get; private set; }
		public string CancelUrl { get; private set; }

		public AccountViewData(string a_returnUrl, bool a_allowAuthoriseAttributeOnAction)
		{
			DisplayAuthLinks = false;
			DisplaySearch = false;

			RouteInformation ri = new RouteInformation(a_returnUrl, MvcApplication.RegisterRoutes);

			ReturnUrl = ri.SanitiseUrl(a_allowAuthoriseAttributeOnAction);
			CancelUrl = ri.SanitiseUrl(false);
		}
	}
}
