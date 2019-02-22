using Microsoft.AspNetCore.Builder;
using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.CrossDomainPolicies
{

	/// <summary>
	/// Extension methods for the Permitted Cross Domain Policies middleware.
	/// </summary>
	public static class CrossDomainPoliciesMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware that adds the X-Permitted-Cross-Domain-Policies header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="option">A <see cref="CrossDomainPoliciesOptions"/> value representing an option to be set.</param>
		public static IApplicationBuilder UseCrossDomainPolicies(this IApplicationBuilder app, CrossDomainPoliciesOptions option)
		{
			return app.UseMiddleware<CrossDomainPoliciesMiddleware>(option);
		}

		/// <summary>
		/// Adds middleware that adds the X-Permitted-Cross-Domain-Policies header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="headerValue">Value to be set for X-Permitted-Cross-Domain-Policies header.</param>
		public static IApplicationBuilder UseCrossDomainPolicies(this IApplicationBuilder app, string headerValue)
		{
			return app.UseMiddleware<CrossDomainPoliciesMiddleware>(headerValue);
		}
	}
}
