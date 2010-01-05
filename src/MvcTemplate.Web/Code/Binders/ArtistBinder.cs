using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class ArtistBinder : ModelBinder
	{
		public ArtistBinder(IArtistsRepository a_repository)
			: base(a_repository)
		{
		}
		
		protected override object BindValue(string a_value)
		{
			IArtist artist = Repository.Artists.FirstOrDefault(a => 0 == String.Compare(a.Name, a_value, true));

			if (null == artist)
			{
				throw new InvalidOperationException(String.Format("Unknown artist: {0}", a_value));
			}

			return artist;
		}
	}
}
