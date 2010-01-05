﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NHibernate;
using NHibernate.Linq;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class UserRepository : Repository, IUserRepository
	{
		public UserRepository(ISession a_session)
			: base(a_session)
		{
		}

		public UserRepository(IDbSession a_session)
			: base(a_session)
		{
		}

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

		public void Register(IUser a_user)
		{
			if (!UserExists(a_user.Credentials.Email))
			{
				Save(a_user as User);
			}
		}

		protected User Get(string a_email)
		{
			return
				(from u in GetAll<User>()
				 where a_email == u.Credentials.Email
				 select u).FirstOrDefault();
		}
	}
}