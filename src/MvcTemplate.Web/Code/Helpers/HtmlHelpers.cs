using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public static class HtmlHelpers
	{
		public static string RouteLink(this HtmlHelper a_html, Hyperlink a_link)
		{
			return a_html.RouteLink(a_link.Text, a_link.Route);
		}

		public static string ActionLink(this HtmlHelper a_html, IArtist a_artist)
		{
			string str = a_html.RouteLink(a_artist.Name, a_artist.Route());
			return str;
		}

		public static string ActionLink(this HtmlHelper a_html, IGenre a_genre)
		{
			return a_html.RouteLink(a_genre.Name, a_genre.Route());
		}
	}
}
