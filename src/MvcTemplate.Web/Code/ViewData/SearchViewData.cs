using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class SearchViewData : ViewData
	{
		public ISearchResults Results { get; set; }
		public bool HasArtists { get { return Results.Artists.Any(); } }
		public bool HasGenres { get { return Results.Genres.Any(); } }

		public SearchViewData()
		{
			DisplaySearch = false;
		}
	}
}
