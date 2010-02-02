using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTemplate.Model
{
	public interface IGenre
	{
		int Id { get; }

		string Name { get; }

		IEnumerable<IArtist> Artists { get; }
	}
}
