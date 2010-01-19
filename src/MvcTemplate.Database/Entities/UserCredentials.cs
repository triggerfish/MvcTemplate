using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace MvcTemplate.Model
{
	public class UserCredentials : IUserCredentials
	{
		[Email]
		public virtual string Email { get; set; }

		[NotNullNotEmpty]
		public virtual string Password { get; set; }
	}
}
