using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace MvcTemplate.Model
{
	public interface IUserCredentials
	{
		[Email]
		string Email { get; set; }
		[NotNullNotEmpty]
		string Password { get; set; }
	}
}
