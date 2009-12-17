using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Triggerfish.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Controllers
{
    public class SearchController : Controller
    {
		private IRepository m_repository;

		public SearchController(IRepository a_repository)
		{
			m_repository = a_repository;
		}

		[Route(Url = "search")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Index()
        {
			return View(new SearchViewData { HasSearchBox = false, NavBarLinks = GenreHyperlinks.CreateLinks(m_repository) });
        }

		[Route(Url = "search")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ViewResult Index(string keyword)
		{
			SearchViewData vd = new SearchViewData
			{
				Results = m_repository.Search(keyword),
				HasSearchBox = false,
				NavBarLinks = GenreHyperlinks.CreateLinks(m_repository)
			};

			return View("Results", vd);
		}
	}
}
