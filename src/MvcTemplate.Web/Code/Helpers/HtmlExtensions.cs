using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MvcTemplate.Model;
using System.Web.Configuration;
using Triggerfish.Ninject;

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

		public static string xValClientSideValidation<T>(this HtmlHelper helper, string elementPrefix)
		{
			bool enabled = false;
			Boolean.TryParse(WebConfigurationManager.AppSettings["EnableClientSideValidation"], out enabled);
			if (true)
			{
				IClientSideValidation v = ObjectFactory.TryGet<IClientSideValidation>();
				if (null != v)
				{
					return v.GetValidationData(new xValClientSideValidationArgs { ElementPrefix = elementPrefix, DataType = typeof(T) });
				}
			}

			return null;
		}
	}
}
