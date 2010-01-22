using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Triggerfish.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web.Controllers
{
    public class ArtistsController : Controller
    {
		private IArtistsRepository m_repository;

		public ArtistsController(IArtistsRepository a_repository)
		{
			m_repository = a_repository;
		}

		[Route(Url = "artists")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Index()
		{
			return View(new ArtistsViewData(m_repository.Artists) { NavBarLinks = GenreHyperlinks.CreateLinks(m_repository, "All") });
		}

		[Route(Url = "genre/{genre}")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Genre(IGenre genre)
		{
			if (ModelState.IsValid) // error
			{
				return View(new GenreViewData(genre) { NavBarLinks = GenreHyperlinks.CreateLinks(m_repository, genre.Name) });
			}
			else
			{
				return View("Error", new ErrorViewData(new Exception(ModelState["genre"].Errors.First().ErrorMessage)) // how to get the duff data?
				{
					NavBarLinks = GenreHyperlinks.CreateLinks(m_repository)
				});
			}
		}

		[Route(Url = "artists/{artist}")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Artist(IArtist artist)
		{
			if (ModelState.IsValid)
			{
				return View(new ArtistViewData(artist) { NavBarLinks = GenreHyperlinks.CreateLinks(m_repository) });
			}
			else
			{
				return View("Error", new ErrorViewData(new Exception(ModelState["artist"].Errors.First().ErrorMessage)) // how to get the duff data?
				{
					NavBarLinks = GenreHyperlinks.CreateLinks(m_repository)
				});
			}
		}

		[Authorize]
		[Route(Url = "secret")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Secret()
		{
			return View(new ViewData { NavBarLinks = GenreHyperlinks.CreateLinks(m_repository, "Secret") });
		}
	}
}
