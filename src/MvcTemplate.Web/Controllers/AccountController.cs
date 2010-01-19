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
		private IAuthenticationProvider m_authentication;
		private IMembershipProvider m_membership;

		public AccountController(IAuthenticationProvider a_authentication, IMembershipProvider a_membership)
		{
			m_authentication = a_authentication;
			m_membership = a_membership;
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult Register()
		{
			ViewData["returnUrl"] = Request.QueryString["returnUrl"];
			return View(new ViewData { DisplaySearch = false });
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Register(IUser user, string returnUrl)
		{
			// problem with the binding of user
			if (!ModelState.IsValid)
			{
				return View(new ViewData { DisplaySearch = false });
			} 
			
			try
			{
				m_membership.Register(user);
				m_authentication.Login(user.Forename, false);
			}
			catch (ValidationException ex)
			{
				ex.ToModelErrors(ModelState, "");
				return View(new ViewData { DisplaySearch = false });
			}

			return DoRedirect(returnUrl);
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Login()
        {
			return View(new ViewData { DisplaySearch = false });
        }

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Login(IUserCredentials credentials, string returnUrl)
		{
			// problem with the binding of credentials
			if (!ModelState.IsValid)
			{
				return View(new ViewData { DisplaySearch = false });
			}

			try
			{
				IUser user = m_membership.Validate(credentials);
				m_authentication.Login(user.Forename, false);
			}
			catch (ValidationException ex)
			{
				ex.ToModelErrors(ModelState, "");
				return View(new ViewData { DisplaySearch = false });
			}

			return DoRedirect(returnUrl);
		}

		[Route(Url = "logout")]
		public ActionResult Logout(string returnUrl)
		{
			m_authentication.Logout();

			return DoRedirect(returnUrl);
		}

		private ActionResult DoRedirect(string returnUrl)
		{
			if (!String.IsNullOrEmpty(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToRoute(RouteHelpers.HomeRoute());
			}
		}
    }
}
