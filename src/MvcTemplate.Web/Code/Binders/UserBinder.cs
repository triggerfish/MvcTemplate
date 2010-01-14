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
		private IUserRepository m_repository;
		private IEncryptor m_encryptor;

		public UserBinder(IUserRepository a_repository, IEncryptor a_encryptor)
		{
			m_repository = a_repository;
			m_encryptor = a_encryptor;
		}
		
		protected override object Bind()
		{
			string forename = GetValue("Forename", false);
			string surname = GetValue("Surname", false);
			string email = GetValue("Email", false);
			string password = m_encryptor.Encrypt(GetValue("Password", false));

			return m_repository.CreateNew(forename, surname, new UserCredentials { Email = email, Password = password });
		}
	}
}
