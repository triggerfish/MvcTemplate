using Ninject.Modules;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public abstract class DatabaseModule : NinjectModule
	{
		public override void Load()
		{
			log4net.Config.XmlConfigurator.Configure();

			FluentConfiguration cfg = Fluently.Configure()
										.Database(CreateDatabase())
										.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Artist>());

			Bind<IDbSession>()
				.To<Session>()
				.InRequestScope()
				.WithConstructorArgument("a_config", cfg);

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
	}
}
