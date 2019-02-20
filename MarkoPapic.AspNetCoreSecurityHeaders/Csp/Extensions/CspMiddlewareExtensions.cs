using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using Microsoft.AspNetCore.Builder;
using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp
{
	public static class CspMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware for using CSP, which adds the Content-Security-Policy header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="builderAction">A delegate used for setting up the <see cref="CspOptionsBuilder"/>.</param>
		/// <returns></returns>
		public static IApplicationBuilder UseCsp(this IApplicationBuilder app, Action<CspOptionsBuilder> builderAction)
		{
			CspOptionsBuilder builder = new CspOptionsBuilder();
			builderAction(builder);
			CspOptions options = builder.Build();
			return app.UseMiddleware<CspMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for using CSP, which adds the Content-Security-Policy header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="csp">Value to be set for Content-Security-Policy header.</param>
		/// <returns></returns>
		public static IApplicationBuilder UseCsp(this IApplicationBuilder app, string csp)
		{
			CspOptions options = new CspOptions {
				Content = csp
			};
			return app.UseMiddleware<CspMiddleware>(options);
		}
	}
}
