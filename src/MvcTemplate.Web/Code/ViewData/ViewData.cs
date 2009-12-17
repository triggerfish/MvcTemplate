using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Web
{
	public class ViewData
	{
		public IList<Hyperlink> NavBarLinks { get; set; }

		public bool HasSearchBox { get; set; }
	
		public ViewData()
		{
			HasSearchBox = true;
		}
	}
}
