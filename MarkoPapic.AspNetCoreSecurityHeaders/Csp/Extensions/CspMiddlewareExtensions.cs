using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using Microsoft.AspNetCore.Builder;
using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Extensions
{
	public static class CspMiddlewareExtensions
	{
		public static IApplicationBuilder UseCsp(this IApplicationBuilder app, Action<CspOptionsBuilder> builderAction)
		{
			var builder = new CspOptionsBuilder();
			builderAction(builder);
			var options = builder.Build();
			return app.UseMiddleware<CspMiddleware>(options);
		}

		public static IApplicationBuilder UseCsp(this IApplicationBuilder app, string csp)
		{
			var options = new CspOptions {
				Content = csp
			};
			return app.UseMiddleware<CspMiddleware>(options);
		}
	}
}
