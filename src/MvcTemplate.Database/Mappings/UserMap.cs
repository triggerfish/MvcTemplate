using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace MvcTemplate.Database
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			Table("Users");
			Id(x => x.Id).GeneratedBy.Native();
			Map(x => x.Forename)
				.Length(50)
				.Not.Nullable();
			Map(x => x.Surname)
				.Length(50)
				.Not.Nullable();
			Component(x => x.Credentials, c => {
				c.Map(y => y.Email)
					.Length(50)
					.Not.Nullable()
					.Unique();
				c.Map(y => y.Password)
					.Length(50)
					.Not.Nullable();
			});
		}
	}
}
