using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Triggerfish.Security;
using MvcTemplate.Model;
using Triggerfish.Validator;

namespace MvcTemplate.Web
{
	public class UserBinder : ModelBinder<IUser>
	{
		private IUserRepository m_repository;
		private IEncryptor m_encryptor;

		public UserBinder(IUserRepository repository, IEncryptor encryptor, IValidator validator)
			: base(validator)
		{
			m_repository = repository;
			m_encryptor = encryptor;
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
