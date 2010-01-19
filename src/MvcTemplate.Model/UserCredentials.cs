using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IUserCredentials
	{
		string Email { get; set; }
		string Password { get; set; }
	}
}
