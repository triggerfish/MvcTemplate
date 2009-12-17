using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace MvcTemplate.Database
{
	public static class SessionExtensions
	{
		public static void WithinTransaction(this ISession a_session, Action<ISession> a_delegate)
		{
			ITransaction tx = a_session.BeginTransaction();
			try
			{
				a_delegate(a_session);
				tx.Commit();
			}
			catch (Exception)
			{
				tx.Rollback();
				throw;
			}
			finally
			{
				tx.Dispose();
			}
		}
	}
}
