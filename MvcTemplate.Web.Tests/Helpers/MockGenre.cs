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
		public static IGenre CreateMockGenre(string a_name)
		{
			return CreateMockGenre(0, a_name, null);
		}

		public static IGenre CreateMockGenre(int a_id, string a_name)
		{
			return CreateMockGenre(a_id, a_name, null);
		}

		public static IGenre CreateMockGenre(int a_id, string a_name, IEnumerable<IArtist> a_artists)
		{
			Mock<IGenre> mock = new Mock<IGenre>();
			mock.Setup(g => g.Id).Returns(a_id);
			mock.Setup(g => g.Name).Returns(a_name);
			mock.Setup(g => g.Artists).Returns(a_artists);
			return mock.Object;
		}

		public static IEnumerable<IGenre> CreateMockGenres(IEnumerable<string> a_names)
		{
			List<IGenre> genres = new List<IGenre>();
			int i = 1;
			a_names.ForEach(n => {
				genres.Add(CreateMockGenre(i++, n));
			});

			return genres;
		}
	}
}
