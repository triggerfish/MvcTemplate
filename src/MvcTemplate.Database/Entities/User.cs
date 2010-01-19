using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MvcTemplate.Model;
using NHibernate.Validator.Constraints;

namespace MvcTemplate.Database
{
	public class User : Entity<int>, IUser
	{
		[NotNullNotEmpty]
		public virtual string Forename { get; set; }

		public virtual string Surname { get; set; }

		[Valid]
		public virtual UserCredentials Credentials { get; set; }

		IUserCredentials IUser.Credentials
		{
			get { return Credentials; }
			set { Credentials = value as UserCredentials; }
		}

		public User()
		{
			Credentials = new UserCredentials();
		}
	}
}
