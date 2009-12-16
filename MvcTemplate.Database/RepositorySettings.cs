using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class RepositorySettings : IRepositorySettings
	{
		public TextWriter SqlLog 
		{
			set { SQLlogger.Log = value; }
		}
	}
}
