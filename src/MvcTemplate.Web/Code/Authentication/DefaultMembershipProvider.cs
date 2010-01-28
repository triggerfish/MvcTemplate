using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MvcTemplate.Model;
using System.Diagnostics;
using Triggerfish.Security;

namespace MvcTemplate.Web
{
	public class DefaultMembershipProvider : IMembershipProvider
	{
		private IUserRepository m_repository;
		private IEncryptor m_encryptor;

		public DefaultMembershipProvider(IUserRepository a_repository, IEncryptor a_encryptor)
		{
			m_repository = a_repository;
			m_encryptor = a_encryptor;
		}

		public IUser Validate(IUserCredentials a_credentials)
		{
			IUser user = m_repository.Get(a_credentials.Email);

			if (null == user || !m_encryptor.IsMatch(a_credentials.Password, user.Credentials.Password))
			{
				throw new AuthenticationException();
			}

			Debug.Assert(null != user);
			return user;
		}

		public void Register(IUser a_user)
		{
			m_repository.Register(a_user);
		}
	}
}
