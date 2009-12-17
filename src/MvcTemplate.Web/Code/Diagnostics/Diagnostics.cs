using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.IO;
using MvcTemplate.Model;
using System.Text.RegularExpressions;

namespace MvcTemplate.Web
{
	public class Diagnostics
	{
		Stopwatch m_timer = new Stopwatch();
		StringWriter m_sqlLog = new StringWriter();

		public void Start()
		{
			ObjectFactory.Get<IRepository>().Settings.SqlLog = m_sqlLog;
			m_timer.Reset();
			m_timer.Start();
		}

		public void Stop()
		{
			m_timer.Stop();
			ObjectFactory.Get<IRepository>().Settings.SqlLog = null;
		}

		public override string ToString()
		{
			StringWriter html = new StringWriter();
			string[] queries = m_sqlLog.ToString().Split(new string[] { m_sqlLog.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			html.WriteLine(@"<div class=""diagnostics"">");

			// page generation time
			html.WriteLine(String.Format("  <p>Page generated in {0}ms</p>", m_timer.ElapsedMilliseconds));

			// sql queries
			html.WriteLine(String.Format("  <p>Executed {0} SQL {1}:</p>", queries.Length, queries.Length == 1 ? "query" : "queries"));
			html.WriteLine("    <ol>");

			foreach (string query in queries)
			{
				html.WriteLine(String.Format("      <li><span class=\"sql\">{0}</span></li>", Regex.Replace(query, "(FROM|WHERE|ORDER BY|--)", "<br/>$1")));
			}

			html.WriteLine("    </ol>");
			html.WriteLine("</div>");

			return html.ToString();
		}
	}
}
