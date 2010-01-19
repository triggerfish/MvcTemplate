using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class UserCredentialsBinder : ModelBinder<IUserCredentials>
	{
		private IUserRepository m_repository;

		public UserCredentialsBinder(IUserRepository a_repository)
		{
			m_repository = a_repository;
		}
		
		protected override object Bind()
		{
			string email = GetValue("Email", false);
			string password = GetValue("Password", false);

			return m_repository.CreateUserCredentials(email, password);
		}
	}
}
