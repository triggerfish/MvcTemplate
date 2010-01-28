﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Triggerfish.Ninject;
using Triggerfish.Web.Diagnostics;
using MvcTemplate.Model;

namespace MvcTemplate.Web
{
	public class Diagnostics : IDiagnostics
	{
		private Stopwatch m_timer = new Stopwatch();
		private StringWriter m_sqlLog = new StringWriter();

		public string Key
		{
			get { return "MvcTemplate.Web.Diagnostics"; }
		}

		public void Start()
		{
			ObjectFactory.Get<IRepositorySettings>().SqlLog = m_sqlLog;
			m_timer.Reset();
			m_timer.Start();
		}

		public void Stop()
		{
			m_timer.Stop();
			ObjectFactory.Get<IRepositorySettings>().SqlLog = null;
		}

		public string ToHtmlString()
		{
			StringWriter html = new StringWriter();
			string[] queries = m_sqlLog.ToString().Split(new string[] { m_sqlLog.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			html.WriteLine(@"<div class=""diagnostics"">");

			// page generation time
			html.WriteLine(String.Format("  <p>Page generated in {0}ms</p>", m_timer.ElapsedMilliseconds));

			// sql queries
			html.WriteLine(String.Format("  <p>Executed {0} SQL {1}:</p>", queries.Length, queries.Length == 1 ? "query" : "queries"));

			if (queries.Length > 0)
			{
				html.WriteLine("    <ol>");
				foreach (string query in queries)
				{
					html.WriteLine(String.Format("      <li><span class=\"sql\">{0}</span></li>", Regex.Replace(query, "(FROM|WHERE|ORDER BY|--)", "<br/>$1")));
				}
				html.WriteLine("    </ol>");
			}
			html.WriteLine("</div>");

			return html.ToString();
		}
	}
}
