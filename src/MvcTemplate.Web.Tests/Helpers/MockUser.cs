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
		public static IUser CreateMockUser(UserCredentials a_credentials)
		{
			return CreateMockUser(0, a_credentials);
		}

		public static IUser CreateMockUser(int a_id, UserCredentials a_credentials)
		{
			// ignore id as it's not defined in IUser - just here for consistency
			Mock<IUser> mock = new Mock<IUser>();
			mock.Setup(u => u.Credentials).Returns(a_credentials);
			return mock.Object;
		}

		public static IEnumerable<IUser> CreateMockUsers(IEnumerable<UserCredentials> a_credentials)
		{
			return MockHelpers.CreateMockObjects<IUser, UserCredentials>(a_credentials, CreateMockUser);
		}
	}
}
