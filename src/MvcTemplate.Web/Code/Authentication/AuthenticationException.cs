using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triggerfish.Validator;

namespace MvcTemplate.Web
{
	public class AuthenticationException : ValidationException
	{
		public AuthenticationException()
			: base("", "Invalid email/password specified")
		{
		}
	}
}
