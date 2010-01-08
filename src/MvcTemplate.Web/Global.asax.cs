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
			ObjectFactory.Load(new MvcTemplate.Database.SqliteModule(WebConfigurationManager.AppSettings["SQLiteDatabaseFilename"]));
			ObjectFactory.Load(new WebDependencies());

			RegisterAllControllersIn("MvcTemplate.Web");

			RegisterRoutes(RouteTable.Routes);
			ModelBinders.Binders.Add(typeof(IGenre), CreateKernel().Get<GenreBinder>());
			ModelBinders.Binders.Add(typeof(IArtist), CreateKernel().Get<ArtistBinder>());
			ModelBinders.Binders.Add(typeof(IUser), CreateKernel().Get<UserBinder>());
		}

		protected override IKernel CreateKernel()
		{
			return ObjectFactory.Kernel;
		}
	}
}