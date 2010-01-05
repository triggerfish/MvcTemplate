using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IUser
	{
		string Forename { get; set; }
		string Surname { get; set; }
		UserCredentials Credentials { get; set; }
	}
}
