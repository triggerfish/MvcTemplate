using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NHibernate;
using Triggerfish.Validator;
using Triggerfish.Ninject;
using Triggerfish.Linq;

namespace MvcTemplate.Database
{
	public class Repository : Triggerfish.NHibernate.Repository
	{
		private IValidator m_validator;

		public Repository(ISession session, IValidator validator)
			: base(session)
		{
			m_validator = validator;
		}

		public override void Save<T>(T target)
		{
			m_validator.Validate(target);
			base.Save(target);
		}

		public override void Save<T>(IEnumerable<T> targets)
		{
			targets.ForEach(t => m_validator.Validate(t));
			base.Save(targets);
		}
	}
}
