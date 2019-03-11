using Microsoft.AspNetCore.Builder;

namespace MarkoPapic.AspNetCoreSecurityHeaders.ReferrerPolicy
{
	/// <summary>
	/// Extension methods for the Referrer Policy middleware.
	/// </summary>
	public static class ReferrerPolicyMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware that adds the Referrer-Policy header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="option">A <see cref="ReferrerPolicyOptions"/> value representing an option to be set.</param>
		public static IApplicationBuilder UseReferrerPolicy(this IApplicationBuilder app, ReferrerPolicyOptions option)
		{
			return app.UseMiddleware<ReferrerPolicyMiddleware>(option);
		}

		/// <summary>
		/// Adds middleware that adds the Referrer-Policy header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="headerValue">Value to be set for Referrer-Policy header.</param>
		public static IApplicationBuilder UseReferrerPolicy(this IApplicationBuilder app, string headerValue)
		{
			return app.UseMiddleware<ReferrerPolicyMiddleware>(headerValue);
		}
	}
}
