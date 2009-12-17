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
		private IRepository m_repository;

		public ArtistsController(IRepository a_repository)
		{
			m_repository = a_repository;
		}

		[Route(Path = "genre/{name}")]
		public ViewResult Genre(string name)
		{
			IEnumerable<IArtist> artists;
			string displayGenreName = "All";
			if (0 == String.Compare(name, "all", true))
			{
				artists = m_repository.Artists;
			}
			else
			{
				IGenre genreObj = m_repository.Genres.Where(g => 0 == String.Compare(g.Name, name, true)).FirstOrDefault();

				if (genreObj == null) // error
				{
					return View("Error", new ErrorViewData(new Exception(String.Format("Unknown genre: {0}", name))) { 
						NavBarLinks = GenreHyperlinks.CreateLinks(m_repository)
					});
				}
				else
				{
					artists = genreObj.Artists;
					displayGenreName = genreObj.Name;
				}
			}

			return View(new GenreViewData(displayGenreName, artists) { NavBarLinks = GenreHyperlinks.CreateLinks(m_repository, name) });
		}

		[Route(Path = "artists/{name}")]
		public ViewResult Artist(string name)
		{
			IArtist artist = m_repository.Artists.FirstOrDefault(a => 0 == String.Compare(a.Name, name, true));

			if (null != artist)
			{
				return View(new ArtistViewData(artist) { NavBarLinks = GenreHyperlinks.CreateLinks(m_repository) });
			}
			else
			{
				return View("Error", new ErrorViewData(new Exception(String.Format("Unknown artist Id: {0}", name))) {
					NavBarLinks = GenreHyperlinks.CreateLinks(m_repository)
				});
			}
		}
	}
}
