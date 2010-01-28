using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Diagnostics;
using Triggerfish.Linq;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class GenreHyperlinks
	{
		public static IList<Hyperlink> CreateLinks(IArtistsRepository repository)
		{
			return CreateLinks(repository, null);
		}

		public static IList<Hyperlink> CreateLinks(IArtistsRepository repository, string toSelect)
		{
			List<Hyperlink> nav = new List<Hyperlink>();
			nav.Add(new Hyperlink()
			{
				Text = "All",
				Route = RouteHelpers.AllArtistsRoute()
			});

			if (null != repository)
			{
				IEnumerable<IGenre> genres = repository.Genres;
				genres.ForEach(g =>	{
					nav.Add(new Hyperlink()	{
						Text = g.Name,
						Route = g.Route()
					});
				});
			}

			nav.Add(new Hyperlink()	{
				Text = "Secret",
				Route = RouteHelpers.SecretRoute()
			});

			if (!String.IsNullOrEmpty(toSelect))
			{
				Hyperlink l = nav.FirstOrDefault(h => (0 == String.Compare(h.Text, toSelect, true)));
				if (null != l)
				{
					l.IsSelected = true;
				}
			}

			return nav;
		}
	}
}
