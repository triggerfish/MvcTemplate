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
		public UserRepository(ISession session, IValidator validator)
			: base(session, validator)
		{
		}

		public UserRepository(IDbSession session, IValidator validator)
			: base(session, validator)
		{
		}

		IUserCredentials IUserRepository.CreateUserCredentials(string email, string password)
		{
			return new UserCredentials { Email = email, Password = password } as IUserCredentials;
		}

		IUser IUserRepository.CreateUser(string forename, string surname, IUserCredentials credentials)
		{
			IUser user = new User { Forename = forename ?? "", Surname = surname ?? "" };
			user.Credentials = credentials;
			return user;
		}

		public bool UserExists(string email)
		{
			return (null != Get(email));
		}

		public IUser Get(string email)
		{
			return
				(from u in GetAll<User>()
				 where email == u.Credentials.Email
				 select u).FirstOrDefault();
		}

		public void Register(IUser user)
		{
			if (UserExists(user.Credentials.Email))
			{
				throw new ValidationException("Email", "The email is already registered");
			}

			Save(user as User);
		}
	}
}
