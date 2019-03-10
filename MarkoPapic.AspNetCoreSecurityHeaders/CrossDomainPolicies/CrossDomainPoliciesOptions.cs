namespace MarkoPapic.AspNetCoreSecurityHeaders.CrossDomainPolicies
{
	/// <summary>
	/// Represents possible options for <see cref="CrossDomainPoliciesMiddleware"/>.
	/// </summary>
	public enum CrossDomainPoliciesOptions
	{
		None = 0,
		MasterOnly,
		ByContentType,
		ByFtpFilename,
		All
	}
}
