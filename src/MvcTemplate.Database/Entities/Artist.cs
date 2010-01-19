using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using NHibernate.Validator.Constraints;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class Artist : Entity<int>, IArtist
	{
		[NotNullNotEmpty]
		public virtual string Name { get; set; }

		public virtual Genre Genre { get; set; }

		[Past]
		public virtual DateTime Formed { get; set; }

		public virtual int NumberOnes { get; set; }

		IGenre IArtist.Genre
		{
			get { return Genre; }
			set { Genre = value as Genre; }
		}
	}
}
