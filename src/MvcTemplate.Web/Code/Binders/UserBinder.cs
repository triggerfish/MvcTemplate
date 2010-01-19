using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class UserBinder : ModelBinder<IUser>
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
			string password = GetValue("Password", false);
			if (!String.IsNullOrEmpty(password))
			{
				password = m_encryptor.Encrypt(password);
			}

			return m_repository.CreateUser(forename, surname, m_repository.CreateUserCredentials(email, password));
		}
	}
}
