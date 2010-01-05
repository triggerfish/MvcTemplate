using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Diagnostics;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class GenreHyperlinks
	{
		public static IList<Hyperlink> CreateLinks(IArtistsRepository a_repository)
		{
			return CreateLinks(a_repository, null);
		}

		public static IList<Hyperlink> CreateLinks(IArtistsRepository a_repository, string a_toSelect)
		{
			List<Hyperlink> nav = new List<Hyperlink>();
			nav.Add(new Hyperlink()
			{
				Text = "All",
				Route = RouteHelpers.AllArtistsRoute()
			});

			if (null != a_repository)
			{
				IEnumerable<IGenre> genres = a_repository.Genres;
				genres.ForEach(g =>
				{
					nav.Add(new Hyperlink()
					{
						Text = g.Name,
						Route = g.Route()
					});
				});
			}

			if (!String.IsNullOrEmpty(a_toSelect))
			{
				Hyperlink l = nav.FirstOrDefault(h => (0 == String.Compare(h.Text, a_toSelect, true)));
				if (null != l)
				{
					l.IsSelected = true;
				}
			}

			return nav;
		}
	}
}
