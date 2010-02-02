using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;
using Triggerfish.Validator;

namespace MvcTemplate.Web
{
	public class UserCredentialsBinder : ModelBinder<IUserCredentials>
	{
		private IUserRepository m_repository;

		public UserCredentialsBinder(IUserRepository repository)
		{
			m_repository = repository;
		}
		
		protected override object Bind()
		{
			string email = GetValue("Email", false);
			string password = GetValue("Password", false);

			return m_repository.CreateUserCredentials(email, password);
		}
	}
}
