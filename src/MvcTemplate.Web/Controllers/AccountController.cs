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
		public ViewResult Register()
		{
			string returnUrl = null;
			if (null != Request)
			{
				returnUrl = Request.QueryString["returnUrl"];
			}
			if (TempData.ContainsKey("RegisterErrors"))
			{
				ModelStateDictionary dic = (ModelStateDictionary)TempData["RegisterErrors"];
				foreach (var kvp in dic)
				{
					ModelState.Add(kvp);
				}
			}

			return View(new AccountViewData(returnUrl, true));
		}

		[Route(Url = "register")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Register(IUser user, string returnUrl)
		{
			// problem with the binding of user
			if (!ModelState.IsValid)
			{
				TempData["RegisterErrors"] = ModelState;
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
				TempData["RegisterErrors"] = ModelState;
				return RedirectToAction("Register", new { returnUrl = returnUrl });
			}

			return Redirect(RouteHelpers.SanitiseUrl(returnUrl, true));
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Login()
        {
			string returnUrl = null;
			if (null != Request)
			{
				returnUrl = Request.QueryString["returnUrl"];
			}
			return View(new AccountViewData(returnUrl, true));
		}

		[Route(Url = "login")]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Login(IUserCredentials credentials, string returnUrl)
		{
			// problem with the binding of credentials
			if (!ModelState.IsValid)
			{
				return View(new AccountViewData(returnUrl, true));
			}

			try
			{
				IUser user = m_membership.Validate(credentials);
				m_authentication.Login(user.Forename, false);
			}
			catch (ValidationException ex)
			{
				ex.ToModelErrors(ModelState, "");
				return View(new AccountViewData(returnUrl, true));
			}

			return Redirect(RouteHelpers.SanitiseUrl(returnUrl, true));
		}

		[Route(Url = "logout")]
		public ActionResult Logout(string returnUrl)
		{
			m_authentication.Logout();

			return Redirect(RouteHelpers.SanitiseUrl(returnUrl, false));
		}

	}
}
