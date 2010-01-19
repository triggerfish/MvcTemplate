using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Security.Principal;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public interface IMembershipProvider
	{
		IUser Validate(IUserCredentials a_credentials);
		void Register(IUser a_user);
	}
}
