using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate;

namespace MvcTemplate.Database
{
	public interface IDbSession
	{
		ISession CreateSession();
		void Close();
	}

	internal class Session : FluentNHibernate.SessionSource, IDbSession
	{
		private ISession m_session;

		public Session(FluentNHibernate.Cfg.FluentConfiguration a_config)
			: base(a_config)
		{
		}

		public Session(IDictionary<string, string> a_properties, PersistenceModel a_model)
			: base(a_properties, a_model)
		{
		}

		public override ISession CreateSession()
		{
			if (null == m_session || !m_session.IsOpen)
			{
				m_session = base.CreateSession();
			}

			return m_session;
		}

		public void Close()
		{
			if (null != m_session)
			{
				m_session.Dispose();
				m_session = null;
			}
		}
	}
}
