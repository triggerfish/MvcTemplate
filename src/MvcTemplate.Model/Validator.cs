using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace MvcTemplate.Model
{
	public interface IValidator
	{
		// should throw a ValidationException if has errors
		void Validate(object a_object);
	}
}
