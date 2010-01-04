using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class GenreBinder : ModelBinder
	{
		public GenreBinder(IRepository a_repository)
			: base(a_repository)
		{
		}
		
		protected override object BindValue(string a_value)
		{
			IGenre genre = Repository.Genres.FirstOrDefault(g => 0 == String.Compare(g.Name, a_value, true));

			if (null == genre)
			{
				throw new InvalidOperationException(String.Format("Unknown genre: {0}", a_value));
			}

			return genre;
		}
	}
}
