using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace MvcTemplate.Database
{
	// class must be public
	public class GenreMap : ClassMap<Genre>
	{
		public GenreMap()
		{
			Table("Genres");
			Id(x => x.Id).GeneratedBy.Native();
			Map(x => x.Name)
				.Length(50)
				.Unique()
				.Not.Nullable();
			HasMany(x => x.Artists)
				.KeyColumn("GenreID")
				.Cascade.All()
				.Inverse();
		}
	}
}
