using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkoPapic.AspNetCoreSecurityHeaders.ContentTypeOptions
{
	/// <summary>
	/// Extension methods for the NoSniff middleware.
	/// </summary>
	public static class NoSniffMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware for using NoSniff, which adds the X-Content-Type-Options header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		public static IApplicationBuilder UseNoSniff(this IApplicationBuilder app)
		{
			return app.UseMiddleware<NoSniffMiddleware>();
		}
	}
}
