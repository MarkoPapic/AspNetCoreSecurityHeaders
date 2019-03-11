using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.ExpectCt
{
	public class ExpectCtOptions
	{
		internal ExpectCtOptions() { }

		internal long MaxAge { get; set; } = 86400;
		internal bool Enforce { get; set; }
		internal string ReportUri { get; set; }
	}
}
