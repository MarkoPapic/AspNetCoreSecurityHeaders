using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.XFrameOptions
{
	public class XFrameOptionsOptions
	{
		internal string AllowedDomain { get; set; }
		internal XFrameOption Option { get; set; }
	}

	public enum XFrameOption
	{
		Deny = 0,
		SameOrigin,
		AllowFromDomain
	}
}
