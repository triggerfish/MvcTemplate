using Ninject.Modules;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;
using System.Reflection;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class SqliteModule : Triggerfish.NHibernate.Ninject.SqliteModule<Artist>
	{
		public SqliteModule(string filename) : base(filename) 
		{ 
		}

		protected override void SetupBindings()
		{
			Bind<IRepositorySettings>()
				.To<RepositorySettings>()
				.InRequestScope();
			Bind<IArtistsRepository>()
				.To<ArtistsRepository>()
				.InRequestScope();
			Bind<IUserRepository>()
				.To<UserRepository>()
				.InRequestScope();

			xVal.ActiveRuleProviders.Providers.Add(new xVal.RulesProviders.NHibernateValidator.NHibernateValidatorRulesProvider(ValidatorMode.UseAttribute));
		}
	}
}
