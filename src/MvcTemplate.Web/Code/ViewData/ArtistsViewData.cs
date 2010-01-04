using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class ArtistsViewData : ViewData
	{
		public IEnumerable<IArtist> Artists { get; private set; }

		public ArtistsViewData(IEnumerable<IArtist> a_artists)
		{
			Artists = a_artists;
		}
	}
}
