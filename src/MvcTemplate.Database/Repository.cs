using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NHibernate;
using NHibernate.Linq;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public abstract class Repository
	{
		protected ISession Session { get; private set; }

		protected Repository(ISession a_session)
		{
			Session = a_session;
		}

		protected Repository(IDbSession a_session)
			: this(a_session.CreateSession())
		{
		}

		public T Get<T>(int a_id)
		{
			return Session.Get<T>(a_id);
		}

		public IOrderedQueryable<T> GetAll<T>()
		{
			return Session.Linq<T>();
		}

		public void Delete<T>(T a_target)
		{
			Session.WithinTransaction(s => s.Delete(a_target));
		}

		public void Save<T>(T a_target)
		{
			Session.WithinTransaction(s => s.SaveOrUpdate(a_target));
		}

		public void Save<T>(IEnumerable<T> a_targets)
		{
			IEnumerable<object> objs = a_targets.Cast<object>();
			Session.WithinTransaction(s => objs.ForEach(s.SaveOrUpdate));
		}
	}
}
