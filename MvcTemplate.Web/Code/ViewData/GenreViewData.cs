using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class GenreViewData : ViewData
	{
		public string SelectedGenre { get; private set; }
		public IEnumerable<IArtist> Artists { get; private set; }

		public GenreViewData(string a_genre, IEnumerable<IArtist> a_artists)
		{
			SelectedGenre = a_genre;
			Artists = a_artists;
		}
	}
}
