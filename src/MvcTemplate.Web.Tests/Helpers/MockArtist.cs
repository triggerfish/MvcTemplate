using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Moq;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Tests
{
	internal static class MockArtist
	{
		public static IArtist CreateMockArtist(string a_name)
		{
			Mock<IArtist> mock = new Mock<IArtist>();
			mock.Setup(a => a.Name).Returns(a_name);
			return mock.Object;
		}

		public static IArtist CreateMockArtist(int a_id, string a_name)
		{
			Mock<IArtist> mock = new Mock<IArtist>();
			mock.Setup(a => a.Id).Returns(a_id);
			mock.Setup(a => a.Name).Returns(a_name);
			return mock.Object;
		}

		public static IEnumerable<IArtist> CreateMockArtists(IEnumerable<string> a_names)
		{
			return MockHelpers.CreateMockObjects<IArtist, string>(a_names, CreateMockArtist);
		}
	}
}
