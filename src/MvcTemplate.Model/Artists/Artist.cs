using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace MvcTemplate.Model
{
	public interface IArtist
	{
		int Id { get; }

		[NotNullNotEmpty(Message = "This field is required")]
		string Name { get; set; }

		[Past]
		DateTime Formed { get; }

		int NumberOnes { get; set; }

		IGenre Genre { get; set; }
	}
}
