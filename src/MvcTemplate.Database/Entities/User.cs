using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class User : Entity<int>, IUser
	{
		private UserCredentials m_credentials = new UserCredentials();

		public virtual string Forename { get; set; }

		public virtual string Surname { get; set; }

		public virtual UserCredentials Credentials 
		{
			get { return m_credentials; }
			set { m_credentials = value; }
		}
	}
}
