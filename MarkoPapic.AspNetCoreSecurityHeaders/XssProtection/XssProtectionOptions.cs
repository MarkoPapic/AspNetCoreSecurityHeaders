using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.XssProtection
{
	public class XssProtectionOptions
	{
		internal bool FilterEnabled { get; set; }
		internal string ReportUri { get; set; }
		internal XssProtectionMode Mode { get; set; }
	}

	internal enum XssProtectionMode
	{
		None = 0,
		Block,
		Report
	}
}
