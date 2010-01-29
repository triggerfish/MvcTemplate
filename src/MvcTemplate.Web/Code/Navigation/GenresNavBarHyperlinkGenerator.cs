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
	public class GenresNavBarHyperlinkGenerator : IHyperlinkGenerator
	{
		private IArtistsRepository m_repository;

		public GenresNavBarHyperlinkGenerator(IArtistsRepository repository)
		{
			m_repository = repository;
		}

		public IEnumerable<Hyperlink> Create(IHyperlinkGeneratorArguments arguments)
		{
			List<Hyperlink> nav = new List<Hyperlink>();
			nav.Add(new Hyperlink() {
				Text = "All",
				Route = RouteHelpers.AllArtistsRoute()
			});

			if (null != m_repository)
			{
				IEnumerable<IGenre> genres = m_repository.Genres;
				genres.ForEach(g => {
					nav.Add(new Hyperlink() {
						Text = g.Name,
						Route = g.Route()
					});
				});
			}

			nav.Add(new Hyperlink() {
				Text = "Secret",
				Route = RouteHelpers.SecretRoute()
			});

			if (null != arguments && !String.IsNullOrEmpty(arguments.Selected))
			{
				Hyperlink l = nav.FirstOrDefault(h => (0 == String.Compare(h.Text, arguments.Selected, true)));
				if (null != l)
				{
					l.IsSelected = true;
				}
			}

			return nav;
		}
	}
}
