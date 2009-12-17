using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class SearchResults : ISearchResults
	{
		public IEnumerable<IArtist> Artists { get; set; }
		public IEnumerable<IGenre> Genres { get; set; }
	}
}
