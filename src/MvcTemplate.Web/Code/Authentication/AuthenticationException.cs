using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class AuthenticationException : ValidationException
	{
		public AuthenticationException()
			: base("Email", "Invalid email/password specified")
		{
		}
	}
}
