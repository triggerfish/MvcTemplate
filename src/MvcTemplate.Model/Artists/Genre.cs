﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace MvcTemplate.Model
{
	public interface IGenre
	{
		int Id { get; }

		[NotNullNotEmpty(Message = "This field is required")]
		string Name { get; }

		IEnumerable<IArtist> Artists { get; }
	}
}