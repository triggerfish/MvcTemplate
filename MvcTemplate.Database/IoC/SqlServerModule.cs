using Ninject.Modules;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class SqlServerModule : DatabaseModule
    {
		protected override IPersistenceConfigurer CreateDatabase()
		{
			return MsSqlConfiguration.MsSql2005
						.ConnectionString(c => c
							.Server(@"PETERADAMS\SQLEXPRESS")
							.Database("music")
							.TrustedConnection())
						.ProxyFactoryFactory("NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu")
						.ShowSql();
		}
    }
}
