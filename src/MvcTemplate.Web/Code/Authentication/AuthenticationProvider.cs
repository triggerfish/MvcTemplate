﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Security.Principal;

namespace MvcTemplate.Web
{
	public interface IAuthenticationProvider
	{
		void Login(string a_name, bool a_createPersistentCookie);
		void Logout();
	}
}
