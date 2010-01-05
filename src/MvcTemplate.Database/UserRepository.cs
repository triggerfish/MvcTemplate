using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NHibernate;
using NHibernate.Linq;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class UserRepository : IUserRepository
	{
		public DataContext DataContext { get; set; }

		public bool UserExists(string a_email)
		{
			return (null != Get(a_email));
		}

		public IUser Get(UserCredentials a_credentials)
		{
			User u = Get(a_credentials.Email);

			if (null != u && u.Credentials.Password == a_credentials.Password)
				return u as IUser;

			return null;
		}

		public void Save(IUser a_user)
		{
			DataContext.Session.WithinTransaction(s => s.SaveOrUpdate(a_user));
		}

		protected User Get(string a_email)
		{
			return
				(from u in DataContext.Users
				 where a_email == u.Credentials.Email
				 select u).FirstOrDefault();
		}
	}
}
