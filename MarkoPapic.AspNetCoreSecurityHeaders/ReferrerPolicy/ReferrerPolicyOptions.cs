namespace MarkoPapic.AspNetCoreSecurityHeaders.ReferrerPolicy
{
	public enum ReferrerPolicyOptions
	{
		NoReferrerWhenDowngrade = 0,
		NoReferrer,
		Origin,
		OriginWhenCrossOrigin,
		SameOrigin,
		StrictOrigin,
		StrictOriginWhenCrossOrigin,
		UnsafeUrl
	}
}
