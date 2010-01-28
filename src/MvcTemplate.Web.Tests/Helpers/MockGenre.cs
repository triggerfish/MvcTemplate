using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Moq;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Tests
{
	internal static class MockGenre
	{
		public static IGenre CreateMockGenre(string name)
		{
			return CreateMockGenre(0, name, null);
		}

		public static IGenre CreateMockGenre(int id, string name)
		{
			return CreateMockGenre(id, name, null);
		}

		public static IGenre CreateMockGenre(int id, string name, IEnumerable<IArtist> artists)
		{
			Mock<IGenre> mock = new Mock<IGenre>();
			mock.Setup(g => g.Id).Returns(id);
			mock.Setup(g => g.Name).Returns(name);
			mock.Setup(g => g.Artists).Returns(artists);
			return mock.Object;
		}

		public static IEnumerable<IGenre> CreateMockGenres(IEnumerable<string> names)
		{
			return MockHelpers.CreateMockObjects<IGenre, string>(names, CreateMockGenre);
		}
	}
}
