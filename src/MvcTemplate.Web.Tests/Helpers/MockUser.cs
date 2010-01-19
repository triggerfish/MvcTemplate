using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Moq;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Tests
{
	internal static class MockUsers
	{
		public static IUserCredentials CreateMockUserCredentials(string a_email, string a_password)
		{
			Mock<IUserCredentials> mock = new Mock<IUserCredentials>();
			mock.Setup(x => x.Email).Returns(a_email);
			mock.Setup(x => x.Password).Returns(a_password);
			return mock.Object;
		}

		public static IUser CreateMockUser(string a_email, string a_password)
		{
			return CreateMockUser(0, CreateMockUserCredentials(a_email, a_password));
		}

		public static IUser CreateMockUser(IUserCredentials a_credentials)
		{
			return CreateMockUser(0, a_credentials);
		}

		public static IUser CreateMockUser(int a_id, IUserCredentials a_credentials)
		{
			// ignore id as it's not defined in IUser - just here for consistency
			Mock<IUser> mock = new Mock<IUser>();
			mock.Setup(u => u.Credentials).Returns(a_credentials);
			return mock.Object;
		}

		public static IEnumerable<IUser> CreateMockUsers(IEnumerable<IUserCredentials> a_credentials)
		{
			return MockHelpers.CreateMockObjects<IUser, IUserCredentials>(a_credentials, CreateMockUser);
		}
	}
}
