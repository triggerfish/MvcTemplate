using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Database
{
	public class Entity<TId>
	{
		public virtual TId Id { get; private set; }

		public virtual bool Equals(Entity<TId> a_rhs)
		{
			if (ReferenceEquals(null, a_rhs))
				return false;
			if (ReferenceEquals(this, a_rhs))
				return true;
			return Equals(Id, a_rhs.Id);
		}

		public override bool Equals(object a_rhs)
		{
			if (ReferenceEquals(null, a_rhs))
				return false;
			if (!(a_rhs is Entity<TId>))
				return false;
			return Equals(a_rhs as Entity<TId>);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
