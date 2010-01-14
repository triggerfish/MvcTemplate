using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using MvcTemplate.Model;

namespace MvcTemplate.Database.Tests
{
	[TestClass]
	public class UserRepositoryTests : DatabaseTest
	{
		private IUserRepository m_repository;

		[TestMethod]
		public void ShouldRecogniseUserExists()
		{
			Assert.IsTrue(m_repository.UserExists("1"));
		}

		[TestMethod]
		public void ShouldRecogniseUserDoesNotExist()
		{
			Assert.IsFalse(m_repository.UserExists("User1"));
		}

		[TestMethod]
		public void ShouldGetUser()
		{
			string s = "2";
			IUser u = m_repository.Get(s);

			Assert.AreNotEqual(null, u);
			Assert.AreEqual(s, u.Forename);
			Assert.AreEqual(s, u.Surname);
			Assert.AreEqual(s, u.Credentials.Email);
			Assert.AreEqual(s, u.Credentials.Password);
		}

		[TestMethod]
		public void ShouldNotGetUserWithInvalidEmail()
		{
			IUser u = m_repository.Get("user@text.com");

			Assert.AreEqual(null, u);
		}

		[TestMethod]
		public void ShouldRegisterUser()
		{
			UserCredentials uc = new UserCredentials {
				Email = "userone@test.com",
				Password = "password"
			};

			User expected = new User {
				Forename = "User",
				Surname = "One",
				Credentials = uc
			};
			
			m_repository.Register(expected);
			
			IUser actual = m_repository.Get(uc.Email);

			Assert.AreNotEqual(null, actual);
			Assert.AreEqual(expected.Forename, actual.Forename);
			Assert.AreEqual(expected.Surname, actual.Surname);
		}

		protected override void SetupContext(ISession a_session)
		{
			m_repository = new UserRepository(a_session);

			for (int i = 1; i <= 4; i++)
			{
				string s = i.ToString();
				User u = new User { Forename = s, Surname = s, Credentials = new UserCredentials { Email = s, Password = s } };
				a_session.Save(u);
			}
		}
	}
}
