using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class GenreBinder : ModelBinder<IGenre>
	{
		protected IArtistsRepository Repository { get; private set; }

		public GenreBinder(IArtistsRepository a_repository)
		{
			Repository = a_repository;
		}
		
		protected override object Bind()
		{
			string genreName = GetValue(ModelName, true);

			IGenre genre = Repository.Genres.FirstOrDefault(g => 0 == String.Compare(g.Name, genreName, true));

			if (null == genre)
			{
				throw new ValidationException(ModelName, String.Format("Unknown genre: {0}", genreName));
			}

			return genre;
		}
	}
}
