using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcTemplate.Model;
using Triggerfish.Web.Mvc;

namespace MvcTemplate.Web.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		private IRepository m_repository;

		public HomeController(IRepository a_repository)
		{
			m_repository = a_repository;
		}

		[Route(IsRoot = true)]
		public ViewResult Index()
		{
			ViewData vd = new ViewData() { 
				NavBarLinks = GenreHyperlinks.CreateLinks(m_repository)
			};
			
			return View(vd);
		}
	}
}
