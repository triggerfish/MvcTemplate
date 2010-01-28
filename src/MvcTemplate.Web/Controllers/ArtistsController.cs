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
	[HandleError]
	[NavBarLinkGenerator(typeof(GenresNavBarHyperlinkGenerator))]
    public class ArtistsController : Controller
    {
		private IArtistsRepository m_repository;

		public ArtistsController(IArtistsRepository repository)
		{
			m_repository = repository;
		}

		[Route(Url = "artists/{page}")]
		[RouteDefault(Name = "page", Value = 1)]
		[RouteConstraint(Name = "page", Regex = @"\d+")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult AllArtists(int page)
		{
			ArtistsViewData vd = new ArtistsViewData(m_repository.Artists.ToPagedList(page, ArtistsViewData.c_itemsPerPageCount));
			vd.NavBarWidget.Selected = "All";
			return View(vd);
		}

		[Route(Url = "genre/{genre}")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Genre(IGenre genre)
		{
			if (ModelState.IsValid) // error
			{
				GenreViewData vd = new GenreViewData(genre);
				vd.NavBarWidget.Selected = genre.Name;
				return View(vd);
			}
			else
			{
				// captured by [HandleError]
				throw new ArgumentException(ModelState["genre"].Errors.First().ErrorMessage);
			}
		}

		[Route(Url = "artist/{artist}")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Artist(IArtist artist)
		{
			if (ModelState.IsValid)
			{
				return View(new ArtistViewData(artist));
			}
			else
			{
				// captured by [HandleError]
				throw new ArgumentException(ModelState["artist"].Errors.First().ErrorMessage);
			}
		}

		[Authorize]
		[Route(Url = "secret")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Secret()
		{
			ViewData vd = new ViewData();
			vd.NavBarWidget.Selected = "Secret";
			return View(vd);
		}
	}
}
