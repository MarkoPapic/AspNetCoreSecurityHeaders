using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.FrameOptions
{
	public class FrameOptionsOptions
	{
		internal FrameOptionsOptions() { }

		internal string AllowedDomain { get; set; }
		internal FrameOption Option { get; set; }
	}

	internal enum FrameOption
	{
		Deny = 0,
		SameOrigin,
		AllowFromDomain
	}
}
