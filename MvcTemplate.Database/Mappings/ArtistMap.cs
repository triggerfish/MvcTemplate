using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace MvcTemplate.Database
{
	public class ArtistMap : ClassMap<Artist>
	{
		public ArtistMap()
		{
			Table("Artists");
			Id(x => x.Id).GeneratedBy.Native();
			Map(x => x.Name)
				.Length(50)
				.Not.Nullable();
			Map(x => x.Formed)
				.Not.Nullable();
			Map(x => x.NumberOnes)
				.Not.Nullable();
			References(x => x.Genre)
				.Column("GenreID")
				.Not.Nullable();
		}
	}
}
