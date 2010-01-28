using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NHibernate;
using NHibernate.Linq;
using Triggerfish.NHibernate;
using Triggerfish.FluentNHibernate;
using Triggerfish.Linq;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public abstract class Repository
	{
		protected ISession Session { get; private set; }

		protected Repository(ISession session)
		{
			Session = session;
		}

		protected Repository(IDbSession session)
			: this(session.CreateSession())
		{
		}

		public T Get<T>(int id)
		{
			return Session.Get<T>(id);
		}

		public IOrderedQueryable<T> GetAll<T>()
		{
			return Session.Linq<T>();
		}

		public void Delete<T>(T target)
		{
			Session.WithinTransaction(s => s.Delete(target));
		}

		public void Save<T>(T target)
		{
			Session.WithinTransaction(s => s.SaveOrUpdate(target));
		}

		public void Save<T>(IEnumerable<T> targets)
		{
			IEnumerable<object> objs = targets.Cast<object>();
			Session.WithinTransaction(s => objs.ForEach(s.SaveOrUpdate));
		}
	}
}
