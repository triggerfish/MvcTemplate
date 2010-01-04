using System;
using System.Collections.Generic;

namespace MvcTemplate.Model
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> a_list, Action<T> a_action)
        {
			if (null == a_list)
				return;

            foreach(T l in a_list)
            {
                a_action(l);
            }
        }
    }
}