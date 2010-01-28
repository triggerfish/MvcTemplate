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
		public static IUserCredentials CreateMockUserCredentials(string email, string password)
		{
			Mock<IUserCredentials> mock = new Mock<IUserCredentials>();
			mock.Setup(x => x.Email).Returns(email);
			mock.Setup(x => x.Password).Returns(password);
			return mock.Object;
		}

		public static IUser CreateMockUser(string email, string password)
		{
			return CreateMockUser(0, CreateMockUserCredentials(email, password));
		}

		public static IUser CreateMockUser(IUserCredentials credentials)
		{
			return CreateMockUser(0, credentials);
		}

		public static IUser CreateMockUser(int id, IUserCredentials credentials)
		{
			// ignore id as it's not defined in IUser - just here for consistency
			Mock<IUser> mock = new Mock<IUser>();
			mock.Setup(u => u.Credentials).Returns(credentials);
			return mock.Object;
		}

		public static IEnumerable<IUser> CreateMockUsers(IEnumerable<IUserCredentials> credentials)
		{
			return MockHelpers.CreateMockObjects<IUser, IUserCredentials>(credentials, CreateMockUser);
		}
	}
}
