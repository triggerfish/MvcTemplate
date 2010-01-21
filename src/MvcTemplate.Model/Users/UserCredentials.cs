using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace MvcTemplate.Model
{
	public interface IUserCredentials
	{
		[NotNullNotEmpty(Message = "This field is required")]
		[Email]
		string Email { get; set; }

		[NotNullNotEmpty(Message = "This field is required")]
		string Password { get; set; }
	}
}
