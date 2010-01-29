﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triggerfish.Ninject;

namespace MvcTemplate.Web
{
	public class ViewData
	{
		public NavBarWidget NavBarWidget { get; set; }

		public bool DisplaySearch { get; set; }
		public bool DisplayAuthLinks { get; set; }

		public ViewData()
		{
			NavBarWidget = new NavBarWidget(null);
			DisplaySearch = true;
			DisplayAuthLinks = true;
		}
	}
}
