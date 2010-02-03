using System.Reflection;
using Ninject.Modules;
using NHibernate.Validator.Engine;
using Triggerfish.NHibernate;
using MvcTemplate.Model;
using Triggerfish.Database;
using NHibernate;

namespace MvcTemplate.Database
{
	public class DatabaseModule : NinjectModule
	{
		private string m_sqliteFilename;

		public DatabaseModule(string filename)
		{
			m_sqliteFilename = filename;
		}

		public override void Load()
		{
			Configuration config = new Configuration(new SqliteDatabase(m_sqliteFilename));

			config.Create<Artist>();
			config.CreateValidator();

			UnitOfWorkFactory.Initialise(config.Config);

			Bind<Triggerfish.Validator.IValidator>()
				.To<Triggerfish.NHibernate.Validator.Validator>()
				.InRequestScope()
				.WithConstructorArgument("engine", config.Validator);

			Bind<ISession>()
				.ToMethod(x => UnitOfWorkFactory.GetCurrentSession());
			Bind<IUnitOfWorkFactory>()
				.To<UnitOfWorkFactory>()
				.InTransientScope();

			Bind<IUser>()
				.To<User>();
			Bind<IUserCredentials>()
				.To<UserCredentials>();
			Bind<IArtist>()
				.To<Artist>();
			Bind<IGenre>()
				.To<Genre>();
			Bind<IRepositorySettings>()
				.To<RepositorySettings>()
				.InRequestScope();
			Bind<IArtistsRepository>()
				.To<ArtistsRepository>()
				.InRequestScope();
			Bind<IUserRepository>()
				.To<UserRepository>()
				.InRequestScope();

			Bind<IClientSideValidation>()
				.To<xValClientSideValidation>()
				.InRequestScope();

			xVal.ActiveRuleProviders.Providers.Add(new xVal.RulesProviders.NHibernateValidator.NHibernateValidatorRulesProvider(ValidatorMode.UseAttribute));
		}
	}
}
