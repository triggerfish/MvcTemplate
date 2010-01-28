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
		public static IEnumerable<TObj> CreateMockObjects<TObj, TData>(IEnumerable<TData> a_data, Func<int, TData, TObj> a_creator)
		{
			List<TObj> objects = new List<TObj>();
			int i = 1;
			a_data.ForEach(n => {
				objects.Add(a_creator(i++, n));
			});
			return objects;
		}
	}
}
