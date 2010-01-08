using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcTemplate.Web
{
	public class FormsAuthenticationProvider : IAuthenticationProvider
	{
		public void SetAuthCookie(string a_email, bool a_createPersistentCookie)
		{
			FormsAuthentication.SetAuthCookie(a_email, a_createPersistentCookie);
		}

		public void Logout()
		{
			FormsAuthentication.SignOut();
		}
	}
}
