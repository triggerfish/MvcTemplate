using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Ninject.Modules;
using NHibernate;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class SqliteModule : DatabaseModule
    {
		private readonly string m_strDbPath;
		private SQLiteConfiguration m_config;

		public SqliteModule(string a_name)
		{
			Uri uri = new Uri(Assembly.GetCallingAssembly().CodeBase);
			m_strDbPath =  Path.Combine(Path.GetDirectoryName(uri.LocalPath), a_name);
		}

		public override void Load()
		{
			base.Load();

			if (!File.Exists(m_strDbPath))
			{
				PersistenceModel pm = new PersistenceModel();
				pm.AddMappingsFromAssembly(typeof(Artist).Assembly);

				Session ss = new Session(m_config.ToProperties(), pm);
				ss.BuildSchema();
				ss.Close();
			}
		}

		protected override IPersistenceConfigurer CreateDatabase()
		{
			m_config = new SQLiteConfiguration()
						.UsingFile(m_strDbPath)
						.ProxyFactoryFactory("NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu")
						.ShowSql();
			return m_config;
		}
    }
}
