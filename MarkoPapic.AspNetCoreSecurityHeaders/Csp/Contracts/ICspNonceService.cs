using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Contracts
{
	public interface ICspNonceService
	{
		string GetNonce();
	}
}
