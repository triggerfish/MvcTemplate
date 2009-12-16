using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface ISearchResults
	{
		IEnumerable<IArtist> Artists { get; }
		IEnumerable<IGenre> Genres { get; }
	}
}
