using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class UserBinder : ModelBinder
	{
		protected IUserRepository Repository { get; private set; }

		public UserBinder(IUserRepository a_repository)
		{
			Repository = a_repository;
		}
		
		protected override object Bind()
		{
			string forename = GetValue("Forename", false);
			string surname = GetValue("Surname", false);
			string email = GetValue("Email", false);
			string password = GetValue("Password", false);

			return Repository.CreateNew(forename, surname, new UserCredentials { Email = email, Password = password });
		}
	}
}
