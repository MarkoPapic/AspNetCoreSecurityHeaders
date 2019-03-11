using Microsoft.AspNetCore.Builder;
using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.XssProtection
{
	/// <summary>
	/// Extension methods for the XSS middleware.
	/// </summary>
	public static class XssProtectionMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware for using XSS, which adds the X-XSS-Protection header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		public static IApplicationBuilder UseXssProtection(this IApplicationBuilder app)
		{
			XssProtectionOptionsBuilder optionsBuilder = new XssProtectionOptionsBuilder();
			XssProtectionOptions options = optionsBuilder.BuildDefault();
			return app.UseMiddleware<XssProtectionMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for using XSS, which adds the X-XSS-Protection header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="optionsAction">A delegate used for setting up the <see cref="XssProtectionOptionsBuilder"/>.</param>
		public static IApplicationBuilder UseXssProtection(this IApplicationBuilder app, Action<XssProtectionOptionsBuilder> optionsAction)
		{
			XssProtectionOptionsBuilder optionsBuilder = new XssProtectionOptionsBuilder();
			optionsAction(optionsBuilder);
			XssProtectionOptions options = optionsBuilder.BuildDefault();
			return app.UseMiddleware<XssProtectionMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for using XSS, which adds the X-XSS-Protection header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="headerValue">Value to be set for X-XSS-Protection header.</param>
		public static IApplicationBuilder UseXssProtection(this IApplicationBuilder app, string headerValue)
		{
			return app.UseMiddleware<XssProtectionMiddleware>(headerValue);
		}
	}
}
