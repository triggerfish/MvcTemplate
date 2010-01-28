using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public static class HtmlExtensions
	{
		public static string RouteLink(this HtmlHelper html, Hyperlink link)
		{
			return html.RouteLink(link.Text, link.Route);
		}

		public static string ActionLink(this HtmlHelper html, IArtist artist)
		{
			string str = html.RouteLink(artist.Name, artist.Route());
			return str;
		}

		public static string ActionLink(this HtmlHelper html, IGenre genre)
		{
			return html.RouteLink(genre.Name, genre.Route());
		}
	}
}
