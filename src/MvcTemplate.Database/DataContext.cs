using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace MvcTemplate.Database
{
	public class DataContext : NHibernateContext
	{
		public DataContext(ISession a_session)
			: base(a_session)
		{
		}

		public IOrderedQueryable<Artist> Artists
		{
			get { return Session.Linq<Artist>(); }
		}

		public IOrderedQueryable<Genre> Genres
		{
			get { return Session.Linq<Genre>(); }
		}
	
		public IOrderedQueryable<User> Users
		{
			get { return Session.Linq<User>(); }
		}
	}
}
