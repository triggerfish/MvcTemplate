using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Triggerfish.Web.Mvc;
using Triggerfish.Web.Routing;
using MvcTemplate.Model;
using Triggerfish.Validator;

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
		[ImportModelState("RegisterErrors")]
		public ViewResult Register(string returnUrl)
		{
			return View(new AccountViewData(returnUrl, true));
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Post)]
		[ExportModelState("RegisterErrors")]
		public ActionResult Register(IUser user, string returnUrl)
		{
			// problem with the binding of user
			if (!ModelState.IsValid)
			{
				return RedirectTo("Register", returnUrl);
			} 
			
			try
			{
				m_membership.Register(user);
				m_authentication.Login(user.Forename, false);
			}
			catch (ValidationException ex)
			{
				ex.ToModelErrors(ModelState, "");
				return RedirectTo("Register", returnUrl);
			}

			return Redirect(UrlHelpers.SanitiseUrl(returnUrl));
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Get)]
		[ImportModelState("LoginErrors")]
		public ViewResult Login(string returnUrl)
        {
			return View(new AccountViewData(returnUrl, true));
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Post)]
		[ExportModelState("LoginErrors")]
		public ActionResult Login(IUserCredentials credentials, string returnUrl)
		{
			// problem with the binding of credentials
			if (!ModelState.IsValid)
			{
				return RedirectTo("Login", returnUrl);
			}

			try
			{
				IUser user = m_membership.Validate(credentials);
				m_authentication.Login(user.Forename, false);
			}
			catch (ValidationException ex)
			{
				ex.ToModelErrors(ModelState, "");
				return RedirectTo("Login", returnUrl);
			}

			return Redirect(UrlHelpers.SanitiseUrl(returnUrl));
		}

		[Route(Url = "logout")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Logout(string returnUrl)
		{
			m_authentication.Logout();

			return Redirect(UrlHelpers.SanitiseUrl(returnUrl, false));
		}

		private RedirectToRouteResult RedirectTo(string a_action, string a_returnUrl)
		{
			RedirectToRouteResult res = RedirectToAction(a_action);
			res.RouteValues.AddReturnUrl(a_returnUrl);
			return res;
		}
	}
}
