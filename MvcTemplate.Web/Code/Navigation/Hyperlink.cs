using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MvcTemplate.Web
{
	public class Hyperlink
	{
		public string Text { get; set; }
		
		public RouteValueDictionary Route { get; set; }
		
		public bool IsSelected { get; set; }
	}
}
