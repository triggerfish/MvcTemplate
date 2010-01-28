using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NHibernate;
using NHibernate.Linq;
using Triggerfish.FluentNHibernate;
using Triggerfish.Validator;
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

		IUserCredentials IUserRepository.CreateUserCredentials(string a_email, string a_password)
		{
			return new UserCredentials { Email = a_email, Password = a_password } as IUserCredentials;
		}

		IUser IUserRepository.CreateUser(string a_forename, string a_surname, IUserCredentials a_credentials)
		{
			IUser user = new User { Forename = a_forename ?? "", Surname = a_surname ?? "" };
			user.Credentials = a_credentials;
			return user;
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
			if (UserExists(a_user.Credentials.Email))
			{
				throw new ValidationException("Email", "The email is already registered");
			}

			Save(a_user as User);
		}
	}
}
