using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class ArtistViewData : ViewData
	{
		public IArtist Artist { get; private set; }

		public ArtistViewData(IArtist artist)
		{
			Artist = artist;
		}
	}
}
