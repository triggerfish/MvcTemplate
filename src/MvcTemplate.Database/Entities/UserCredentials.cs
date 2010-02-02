using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace MvcTemplate.Model
{
	public class UserCredentials : IUserCredentials
	{
		[NotNullNotEmpty(Message = "This field is required")]
		[Email]
		public virtual string Email { get; set; }

		[NotNullNotEmpty(Message = "This field is required")]
		public virtual string Password { get; set; }
	}
}
