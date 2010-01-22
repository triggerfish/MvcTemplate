using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Triggerfish.Web.Mvc;
using MvcTemplate.Model;
using System.Web.Security;
using Triggerfish.Testing.Web.Mvc;

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
		[ImportModelStateFromTempData("RegisterErrors")]
		public ViewResult Register(string returnUrl)
		{
			return View(new AccountViewData(returnUrl, true));
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Post)]
		[ExportModelStateToTempData("RegisterErrors")]
		public ActionResult Register(IUser user, string returnUrl)
		{
			// problem with the binding of user
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Register", new { returnUrl = returnUrl });
			} 
			
			try
			{
				m_membership.Register(user);
				m_authentication.Login(user.Forename, false);
			}
			catch (ValidationException ex)
			{
				ex.ToModelErrors(ModelState, "");
				return RedirectToAction("Register", new { returnUrl = returnUrl });
			}

			return this.SanitisedRedirect(returnUrl);
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Get)]
		[ImportModelStateFromTempData("LoginErrors")]
		public ViewResult Login(string returnUrl)
        {
			return View(new AccountViewData(returnUrl, true));
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Post)]
		[ExportModelStateToTempData("LoginErrors")]
		public ActionResult Login(IUserCredentials credentials, string returnUrl)
		{
			// problem with the binding of credentials
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Login", new { returnUrl = returnUrl });
			}

			try
			{
				IUser user = m_membership.Validate(credentials);
				m_authentication.Login(user.Forename, false);
			}
			catch (ValidationException ex)
			{
				ex.ToModelErrors(ModelState, "");
				return RedirectToAction("Login", new { returnUrl = returnUrl });
			}

			return this.SanitisedRedirect(returnUrl);
		}

		[Route(Url = "logout")]
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Logout(string returnUrl)
		{
			m_authentication.Logout();

			return this.SanitisedRedirect(returnUrl, false);
		}

	}
}
