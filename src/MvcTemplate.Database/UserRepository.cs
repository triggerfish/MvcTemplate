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

		IUser IUserRepository.CreateNew(string a_forename, string a_surname, UserCredentials a_credentials)
		{
			return new User { Forename = a_forename ?? "", Surname = a_surname ?? "", Credentials = a_credentials } as IUser;
		}

		public bool UserExists(string a_email)
		{
			return (null != Get(a_email));
		}

		public IUser Get(string a_email)
		{
			return
				(from u in GetAll<User>()
				 where a_email == u.Credentials.Email
				 select u).FirstOrDefault();
		}

		public void Register(IUser a_user)
		{
			if (!UserExists(a_user.Credentials.Email))
			{
				Save(a_user as User);
			}
		}
	}
}
