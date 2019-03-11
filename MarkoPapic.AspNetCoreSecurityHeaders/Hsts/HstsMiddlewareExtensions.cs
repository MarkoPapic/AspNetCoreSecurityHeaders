using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Hsts
{
	/// <summary>
	/// Extension methods for the HSTS middleware.
	/// </summary>
	public static class HstsMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware for using HSTS, which adds the Strict-Transport-Security header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		public static IApplicationBuilder UseHsts(this IApplicationBuilder app)
		{
			HstsOptions options = new HstsOptions();
			return app.UseMiddleware<HstsMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for using HSTS, which adds the Strict-Transport-Security header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="optionsAction">A delegate used for setting up the <see cref="HstsOptions"/>.</param>
		public static IApplicationBuilder UseHsts(this IApplicationBuilder app, Action<HstsOptions> optionsAction)
		{
			HstsOptions options = new HstsOptions();
			optionsAction(options);
			return app.UseMiddleware<HstsMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for using HSTS, which adds the Strict-Transport-Security header.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="headerValue">Value to be set for Strict-Transport-Security header.</param>
		/// <returns></returns>
		public static IApplicationBuilder UseHsts(this IApplicationBuilder app, string headerValue)
		{
			return app.UseMiddleware<HstsMiddleware>(headerValue);
		}
	}
}
