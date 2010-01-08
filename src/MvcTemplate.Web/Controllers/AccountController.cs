using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Triggerfish.Web.Mvc;
using MvcTemplate.Model;
using System.Web.Security;

namespace MvcTemplate.Web.Controllers
{
    public class AccountController : Controller
    {
		private IUserRepository m_repository;
		private IAuthenticationProvider m_authentication;

		public AccountController(IUserRepository a_repository, IAuthenticationProvider a_authentication)
		{
			m_repository = a_repository;
			m_authentication = a_authentication;
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Register()
		{
			return View(new ViewData { DisplaySearch = false });
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Register(IUser user, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(new ViewData { DisplaySearch = false });
			}

			// validation!

			m_repository.Register(user);
			m_authentication.SetAuthCookie(user.Forename, false);

			return Redirect(returnUrl);
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Login()
        {
			return View(new ViewData { DisplaySearch = false, DisplayRegister = false });
        }

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Login(IUser user, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(new ViewData { DisplaySearch = false });
			}

			// validation!
			// password encryption!

			user = m_repository.Get(user.Credentials);
			if (null == user)
			{
				ModelState.AddModelError("Email", "Invalid email/password specified");
				return View(new ViewData { DisplaySearch = false, DisplayRegister = false });
			}

			m_authentication.SetAuthCookie(user.Forename, false);

			return Redirect(returnUrl);
		}

		[Route(Url = "logout")]
		public ActionResult Logout(string returnUrl)
		{
			m_authentication.Logout();

			return Redirect(returnUrl);
		}
    }
}
