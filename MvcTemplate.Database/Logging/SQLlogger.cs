using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using log4net.Core;
using System.IO;

namespace MvcTemplate.Database
{
	public class SQLlogger : AppenderSkeleton
	{
		private static TextWriter m_logger;
		public static TextWriter Log 
		{
			set { m_logger = value; }
		}

		protected override void Append(LoggingEvent loggingEvent)
		{
			if (null != m_logger && (loggingEvent.LoggerName == "NHibernate.SQL"))
			{
				m_logger.WriteLine(loggingEvent.MessageObject);
			}
		}
	}
}
