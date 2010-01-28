using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcTemplate.Web
{
	public class FormsAuthenticationProvider : IAuthenticationProvider
	{
		public void Login(string name, bool createPersistentCookie)
		{
			FormsAuthentication.SetAuthCookie(name, createPersistentCookie);
		}

		public void Logout()
		{
			FormsAuthentication.SignOut();
		}
	}
}
