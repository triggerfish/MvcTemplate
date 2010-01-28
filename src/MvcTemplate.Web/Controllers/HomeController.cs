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
	[NavBarLinkGenerator(typeof(GenresNavBarHyperlinkGenerator))]
	public class HomeController : Controller
	{
		private IArtistsRepository m_repository;

		public HomeController(IArtistsRepository repository)
		{
			m_repository = repository;
		}

		[Route(IsRoot = true)]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Index()
		{
			return View(new ViewData());
		}
	}
}
