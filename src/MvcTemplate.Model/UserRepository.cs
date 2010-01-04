using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IUserRepository
	{
		IUser FindByCredentials(UserCredentials a_credentials);
		bool EmailExists(IUser a_user);
	}
}
