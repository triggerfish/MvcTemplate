using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace MvcTemplate.Database.Tests
{
	public abstract class DatabaseTest
	{
		protected SessionSource SessionSource { get; private set; }
		protected ISession Session { get; private set; }

		[TestInitialize]
		public void Setup() 
		{
			SQLiteConfiguration config = new SQLiteConfiguration()
				.InMemory()
				.ProxyFactoryFactory("NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu")
				.ShowSql();

			PersistenceModel pm = new PersistenceModel();
			pm.AddMappingsFromAssembly(typeof(Artist).Assembly);
			
			SessionSource = new SessionSource(config.ToProperties(), pm);
			Session = SessionSource.CreateSession();
			SessionSource.BuildSchema(Session);

			Session.WithinTransaction(SetupContext);

			Session.Flush();
			Session.Clear();
		}

		[TestCleanup]
		public void TearDown()
		{
			Session.Close();
			Session.Dispose();
		}

		protected virtual void SetupContext(ISession a_session)
		{
		}
	}
}
