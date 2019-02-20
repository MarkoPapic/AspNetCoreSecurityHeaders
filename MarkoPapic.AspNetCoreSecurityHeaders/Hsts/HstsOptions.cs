using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Hsts
{
	/// <summary>
	/// Options for the Hsts Middleware
	/// </summary>
	public class HstsOptions
	{
		/// <summary>
		/// Sets the max-age parameter of the Strict-Transport-Security header.
		/// </summary>
		/// <remarks>
		/// Max-age is required; defaults to 30 days.
		/// See: https://tools.ietf.org/html/rfc6797#section-6.1.1
		/// </remarks>
		public TimeSpan MaxAge { get; set; } = TimeSpan.FromDays(30);

		/// <summary>
		/// Enables includeSubDomain parameter of the Strict-Transport-Security header.
		/// </summary>
		/// <remarks>
		/// See: https://tools.ietf.org/html/rfc6797#section-6.1.2
		/// </remarks>
		public bool IncludeSubDomains { get; set; }

		/// <summary>
		/// Sets the preload parameter of the Strict-Transport-Security header.
		/// </summary>
		/// <remarks>
		/// See https://hstspreload.org/.
		/// </remarks>
		public bool Preload { get; set; }
	}
}
