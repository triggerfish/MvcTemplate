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
    public class AccountController : Controller
    {
		private IArtistsRepository m_repository;

		public AccountController(IArtistsRepository a_repository)
		{
			m_repository = a_repository;
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Register()
		{
			return View(new ViewData());
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Register(string user) // change to User object
		{
			return View();
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Login()
        {
            return View(new ViewData());
        }

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Login(string user) // change to User object
		{
			return View();
		}

		[Route(Url = "logout")]
		public ViewResult Logout()
		{
			return View();
		}
    }
}
