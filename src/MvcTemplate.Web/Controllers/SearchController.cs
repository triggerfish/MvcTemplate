using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Triggerfish.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Controllers
{
	[NavBarLinkGenerator(typeof(GenresNavBarHyperlinkGenerator))]
	public class SearchController : Controller
    {
		private IArtistsRepository m_repository;

		public SearchController(IArtistsRepository repository)
		{
			m_repository = repository;
		}

		[Route(Url = "search")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Index()
        {
			return View(new SearchViewData());
        }

		[Route(Url = "search")]
		[AcceptVerbs(HttpVerbs.Post)]
		[ExportModel("SearchResults", typeof(SearchViewData))]
		public ActionResult Index(string keyword)
		{
			ViewData.Model = new SearchViewData {
				Results = m_repository.Search(keyword)
			};

			return RedirectToAction("Results");
		}

		[Route(Url = "search-results")]
		[AcceptVerbs(HttpVerbs.Get)]
		[ImportModel("SearchResults", typeof(SearchViewData))]
		public ActionResult Results()
		{
			if (ViewData.Model == null)
			{
				return RedirectToAction("Index");
			}

			return View(ViewData.Model);
		}
	}
}
