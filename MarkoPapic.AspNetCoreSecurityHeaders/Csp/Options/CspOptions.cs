using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options
{
	public class CspOptions
	{
		internal string Content { get; set; }
		internal ReportGroupOptions ReportingGroup { get; set; }
	}
}
