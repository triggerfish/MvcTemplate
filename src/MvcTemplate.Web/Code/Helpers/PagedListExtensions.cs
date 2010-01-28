using System;
using System.Collections.Generic;
using System.Linq;
using Triggerfish.Web.Mvc;
using MvcTemplate.Model;
using Triggerfish.Ninject;

namespace MvcTemplate.Web
{
	public static class PagedListExtensions
	{
		public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
		{
			if (pageNumber < 1)
				pageNumber = 1;

			IPageLinksAlgorithm alg = ObjectFactory.TryGet<IPageLinksAlgorithm>();
			IPageLinkHtmlGenerator html = ObjectFactory.TryGet<IPageLinkHtmlGenerator>();

			if (null == alg || null == html)
				return null;

			PagedList<T> pagedList = new PagedList<T>(alg, html);
			pagedList.Paginate(source, pageNumber - 1, pageSize);
			return pagedList;
		}
	}
}
