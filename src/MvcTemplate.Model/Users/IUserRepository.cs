using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IUserRepository
	{
		IUserCredentials CreateUserCredentials(string email, string password);
		IUser CreateUser(string forename, string surname, IUserCredentials credentials);
		bool UserExists(string email);
		IUser Get(string email);
		void Register(IUser user);
	}
}
