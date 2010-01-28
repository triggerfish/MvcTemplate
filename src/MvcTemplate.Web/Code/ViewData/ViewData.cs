using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triggerfish.Ninject;

namespace MvcTemplate.Web
{
	public class ViewData
	{
		public NavBarWidget NavBarWidget { get; private set; }

		public bool DisplaySearch { get; set; }
		public bool DisplayAuthLinks { get; set; }

		public ViewData()
		{
			NavBarWidget = new NavBarWidget();
			DisplaySearch = true;
			DisplayAuthLinks = true;
		}
	}
}
