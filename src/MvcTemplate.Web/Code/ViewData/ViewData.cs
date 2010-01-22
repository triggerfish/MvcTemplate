using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Web
{
	public class ViewData
	{
		public IList<Hyperlink> NavBarLinks { get; set; }

		public bool DisplaySearch { get; set; }
		public bool DisplayAuthLinks { get; set; }

		public ViewData()
		{
			DisplaySearch = true;
			DisplayAuthLinks = true;
		}
	}
}
