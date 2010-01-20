using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public class UserCredentials : IUserCredentials
	{
		public virtual string Email { get; set; }

		public virtual string Password { get; set; }
	}
}
