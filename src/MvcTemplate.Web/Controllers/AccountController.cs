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

		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Register()
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Register(string user) // change to User object
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Login()
        {
            return View(new ViewData());
        }

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Login(string user) // change to User object
		{
			return View();
		}

		public ViewResult Logout()
		{
			return View();
		}
    }
}
