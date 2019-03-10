using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Contracts
{
	/// <summary>
	/// Interface to be implemented by the class to be used for nonce generation for the <see cref="Builders.FetchDirectiveBuilder"/>.
	/// </summary>
	public interface ICspNonceService
	{
		/// <summary>
		/// Generates the nonce base64 string.
		/// </summary>
		/// <returns>Base64 string representing the nonce.</returns>
		string GetNonce();
	}
}
