using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace MvcTemplate.Model
{
	public class ValidationException : Exception
	{
		public NameValueCollection Errors { get; private set; }

		public ValidationException()
		{
			Errors = new NameValueCollection();
		}
	
		public ValidationException(string a_key, string a_value)
			: this()
		{
			Errors.Add(a_key, a_value);
		}
	}
}
