using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Configuration;
using Ninject;
using Ninject.Web.Mvc;
using Triggerfish.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class MvcApplication : NinjectHttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.RegisterRoutes();

			// ~/controller/action
			routes.MapFriendlyUrlRoute(
				null,
				"{controller}/{action}"
			);
		}

		protected override void OnApplicationStarted()
		{
			RegisterAllControllersIn("MvcTemplate.Web");

			RegisterRoutes(RouteTable.Routes);

			ObjectFactory.Load(new MvcTemplate.Database.SqliteModule(WebConfigurationManager.AppSettings["SQLiteDatabaseFilename"]));
		}

		protected override IKernel CreateKernel()
		{
			return ObjectFactory.Kernel;
		}
	}
}