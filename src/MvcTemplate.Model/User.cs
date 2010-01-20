using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace MvcTemplate.Model
{
	public interface IUser
	{
		[NotNullNotEmpty]
		string Forename { get; set; }
		string Surname { get; set; }
		[Valid]
		IUserCredentials Credentials { get; set; }
	}
}
