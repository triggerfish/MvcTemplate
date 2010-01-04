using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class GenreViewData : ArtistsViewData
	{
		public string SelectedGenre { get; private set; }

		public GenreViewData(IGenre a_genre)
			: base(a_genre.Artists)
		{
			SelectedGenre = a_genre.Name;
		}
	}
}
