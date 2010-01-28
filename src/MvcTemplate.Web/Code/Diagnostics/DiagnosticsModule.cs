using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using MvcTemplate.Model;
using System.Text;

namespace MvcTemplate.Web
{
	public class DiagnosticsModule : IHttpModule
	{
		public void Init(HttpApplication appContext)
		{
			appContext.PreRequestHandlerExecute += (sender, e) =>
			{
				// Set up a new empty log
				HttpContext context = ((HttpApplication)sender).Context;
				Diagnostics d = new Diagnostics();
				context.Items["MvcTemplate.Web.Diagnostics"] = d;
				d.Start();
			};

			appContext.PostRequestHandlerExecute += (sender, e) =>
			{
				HttpContext context = ((HttpApplication)sender).Context;
				Diagnostics d = context.Items["MvcTemplate.Web.Diagnostics"] as Diagnostics;

				context.Response.Filter = new DiagnosticsFilter(context.Response.Filter, d.ToString());

				context.Items.Remove("MvcTemplate.Web.Diagnostics");
			};
		}

		public void Dispose() { /* Not needed */ }
	}
}
