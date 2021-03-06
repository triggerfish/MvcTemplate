﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;
using Triggerfish.Validator;

namespace MvcTemplate.Web
{
	public class ArtistBinder : ModelBinder<IArtist>
	{
		protected IArtistsRepository Repository { get; private set; }

		public ArtistBinder(IArtistsRepository repository)
		{
			Repository = repository;
		}
		
		protected override object Bind()
		{
			string artistName = GetValue(ModelName, true);
			IArtist artist = Repository.Artists.FirstOrDefault(a => 0 == String.Compare(a.Name, artistName, true));

			if (null == artist)
			{
				throw new ValidationException(ModelName, String.Format("Unknown artist: {0}", artistName));
			}

			return artist;
		}
	}
}
