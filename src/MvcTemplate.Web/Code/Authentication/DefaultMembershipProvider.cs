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

		public DefaultMembershipProvider(IUserRepository repository, IEncryptor encryptor)
		{
			m_repository = repository;
			m_encryptor = encryptor;
		}

		public IUser Validate(IUserCredentials credentials)
		{
			IUser user = m_repository.Get(credentials.Email);

			if (null == user || !m_encryptor.IsMatch(credentials.Password, user.Credentials.Password))
			{
				throw new AuthenticationException();
			}

			Debug.Assert(null != user);
			return user;
		}

		public void Register(IUser user)
		{
			m_repository.Register(user);
		}
	}
}
