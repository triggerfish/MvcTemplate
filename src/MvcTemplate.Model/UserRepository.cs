using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IUserRepository
	{
		bool UserExists(string a_email);

		IUser Get(UserCredentials a_credentials);

		void Save(IUser a_user);
	}
}
