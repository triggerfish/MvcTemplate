using Ninject.Modules;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;
using System.Reflection;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public abstract class DatabaseModule : NinjectModule
	{
		public override void Load()
		{
			log4net.Config.XmlConfigurator.Configure();

			ValidatorEngine ve = new ValidatorEngine();
			FluentConfiguration cfg = Fluently.Configure()
										.Database(CreateDatabase())
										.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Artist>())
										.ExposeConfiguration(c => ConfigureValidator(c, ve));

			Bind<IDbSession>()
				.To<Session>()
				.InRequestScope()
				.WithConstructorArgument("a_config", cfg);

			Bind<MvcTemplate.Model.IValidator>()
				.To<Validator>()
				.InRequestScope()
				.WithConstructorArgument("a_engine", ve);

			Bind<IRepositorySettings>()
				.To<RepositorySettings>()
				.InRequestScope();
			Bind<IArtistsRepository>()
				.To<ArtistsRepository>()
				.InRequestScope();
			Bind<IUserRepository>()
				.To<UserRepository>()
				.InRequestScope();
		}

		protected abstract IPersistenceConfigurer CreateDatabase();

		private void ConfigureValidator(NHibernate.Cfg.Configuration a_config, ValidatorEngine a_engine)
		{
			XmlConfiguration nhvc = new XmlConfiguration();
			nhvc.Properties[NHibernate.Validator.Cfg.Environment.ApplyToDDL] = "true";
			nhvc.Properties[NHibernate.Validator.Cfg.Environment.AutoregisterListeners] = "true";
			nhvc.Properties[NHibernate.Validator.Cfg.Environment.ValidatorMode] = "UseAttribute";

			a_engine.Configure(nhvc);
			ValidatorInitializer.Initialize(a_config, a_engine);
		}
	}
}
