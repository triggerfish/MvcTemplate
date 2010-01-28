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
		public static IArtist CreateMockArtist(string name)
		{
			Mock<IArtist> mock = new Mock<IArtist>();
			mock.Setup(a => a.Name).Returns(name);
			return mock.Object;
		}

		public static IArtist CreateMockArtist(int id, string name)
		{
			Mock<IArtist> mock = new Mock<IArtist>();
			mock.Setup(a => a.Id).Returns(id);
			mock.Setup(a => a.Name).Returns(name);
			return mock.Object;
		}

		public static IEnumerable<IArtist> CreateMockArtists(IEnumerable<string> names)
		{
			return MockHelpers.CreateMockObjects<IArtist, string>(names, CreateMockArtist);
		}
	}
}
