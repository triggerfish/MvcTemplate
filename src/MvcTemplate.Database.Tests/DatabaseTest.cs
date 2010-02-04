using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using Triggerfish.NHibernate;
using Triggerfish.Database;
using NHibernate.Tool.hbm2ddl;

namespace MvcTemplate.Database.Tests
{
	public abstract class DatabaseTest
	{
		protected UnitOfWork m_uow;
		protected ISession Session { get; private set; }

		[TestInitialize]
		public void Setup() 
		{
			FluentConfiguration configuration = Fluently.Configure()
				.Database(SQLiteConfiguration.Standard
					.InMemory()
					.ProxyFactoryFactory("NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu")
					.ShowSql());

			PersistenceModel pm = new PersistenceModel();
			pm.AddMappingsFromAssembly(typeof(Artist).Assembly);

			SingleConnectionSessionSourceForSQLiteInMemoryTesting ss = new SingleConnectionSessionSourceForSQLiteInMemoryTesting(configuration.BuildConfiguration().Properties, pm);
			ss.BuildSchema();

			Session = ss.CreateSession();
			m_uow = new UnitOfWork(Session);
			
			SetupContext(Session);
			m_uow.Commit();

			Session.Clear();
		}

		[TestCleanup]
		public void TearDown()
		{
			m_uow.End();
		}

		protected virtual void SetupContext(ISession session)
		{
		}
	}
}
