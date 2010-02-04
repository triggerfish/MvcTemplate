using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IArtist
	{
		int Id { get; }

		string Name { get; set; }

		DateTime Formed { get; }

		int NumberOnes { get; set; }

		IGenre Genre { get; set; }
	}
}
