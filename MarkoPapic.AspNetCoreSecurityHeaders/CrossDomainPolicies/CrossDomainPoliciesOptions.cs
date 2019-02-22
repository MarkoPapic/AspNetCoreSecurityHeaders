namespace MarkoPapic.AspNetCoreSecurityHeaders.CrossDomainPolicies
{
	public enum CrossDomainPoliciesOptions
	{
		None = 0,
		MasterOnly,
		ByContentType,
		ByFtpFilename,
		All
	}
}
