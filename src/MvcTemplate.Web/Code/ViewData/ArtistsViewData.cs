using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triggerfish.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class ArtistsViewData : ViewData
	{
		public const int c_itemsPerPageCount = 5;
		public const int c_pageLinksPerPageCount = 3;

		public PagedList<IArtist> ArtistsPagedList { get; private set; }

		public ArtistsViewData(PagedList<IArtist> a_artists)
		{
			ArtistsPagedList = a_artists;
		}
	}
}
