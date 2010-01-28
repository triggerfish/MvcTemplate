using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Moq;
using Triggerfish.Linq;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Tests
{
	internal static class MockHelpers
	{
		public static IEnumerable<TObj> CreateMockObjects<TObj, TData>(IEnumerable<TData> data, Func<int, TData, TObj> creator)
		{
			List<TObj> objects = new List<TObj>();
			int i = 1;
			data.ForEach(n => {
				objects.Add(creator(i++, n));
			});
			return objects;
		}
	}
}
