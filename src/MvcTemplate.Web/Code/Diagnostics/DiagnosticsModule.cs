using System;
using System.Text;
using Triggerfish.Web.Diagnostics;

namespace MvcTemplate.Web
{
	public class DiagnosticsModule : Triggerfish.Web.Diagnostics.DiagnosticsModule
	{
		protected override IDiagnostics CreateDiagnostics()
		{
			return new Diagnostics();
		}
	}
}
