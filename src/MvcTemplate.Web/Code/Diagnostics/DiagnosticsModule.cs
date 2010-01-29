using System;
using System.Text;
using Triggerfish.Web.Diagnostics;
using Triggerfish.Ninject;

namespace MvcTemplate.Web
{
	public class DiagnosticsModule : Triggerfish.Web.Diagnostics.DiagnosticsModule
	{
		protected override IDiagnostics CreateDiagnostics()
		{
			return ObjectFactory.TryGet<Diagnostics>();
		}
	}
}
