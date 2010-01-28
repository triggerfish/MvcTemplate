using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class SearchViewData : ViewData
	{
		public ISearchResults Results { get; set; }

		public SearchViewData()
		{
			DisplaySearch = false;
		}
	}
}
