using System.Reflection;
using Ninject.Modules;
using NHibernate.Validator.Engine;
using Triggerfish.FluentNHibernate;
using Triggerfish.NHibernate;
using MvcTemplate.Model;

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
			Configuration<Artist> config = new Configuration<Artist>(new SqliteDatabase(m_sqliteFilename));

			config.Create();
			config.CreateValidator();

			Bind<IDbSession>()
				.To<Session>()
				.InRequestScope()
				.WithConstructorArgument("config", config.Config);

			Bind<Triggerfish.Validator.IValidator>()
				.To<Triggerfish.NHibernate.Validator.Validator>()
				.InRequestScope()
				.WithConstructorArgument("engine", config.Validator);

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
