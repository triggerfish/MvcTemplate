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
		protected IArtistsRepository Repository { get; private set; }

		public ArtistBinder(IArtistsRepository a_repository)
		{
			Repository = a_repository;
		}
		
		protected override object Bind()
		{
			string artistName = GetValue(ModelName, true);
			IArtist artist = Repository.Artists.FirstOrDefault(a => 0 == String.Compare(a.Name, artistName, true));

			if (null == artist)
			{
				throw new ModelBinderException(ModelName, String.Format("Unknown artist: {0}", artistName));
			}

			return artist;
		}
	}
}
