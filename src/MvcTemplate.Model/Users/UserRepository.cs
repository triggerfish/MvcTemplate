using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IUserRepository
	{
		IUserCredentials CreateUserCredentials(string a_email, string a_password);
		IUser CreateUser(string a_forename, string a_surname, IUserCredentials a_credentials);
		bool UserExists(string a_email);
		IUser Get(string a_email);
		void Register(IUser a_user);
	}
}
