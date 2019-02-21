using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkoPapic.AspNetCoreSecurityHeaders.XFrameOptions
{
	public static class XFrameOptionsMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware for adding the X-Frame-Options header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="optionsAction">A delegate used for setting up the <see cref="XFrameOptionsOptions"/>.</param>
		public static IApplicationBuilder UseXFrameOptions(this IApplicationBuilder app, Action<XFrameOptionsOptionsBuilder> optionsAction)
		{
			XFrameOptionsOptionsBuilder optionsBuilder = new XFrameOptionsOptionsBuilder();
			optionsAction(optionsBuilder);
			XFrameOptionsOptions options = optionsBuilder.Build();
			return app.UseMiddleware<XFrameOptionsMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for adding the X-Frame-Options header.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="headerValue">Value to be set for X-Frame-Options header.</param>
		/// <returns></returns>
		public static IApplicationBuilder UseXFrameOptions(this IApplicationBuilder app, string headerValue)
		{
			return app.UseMiddleware<XFrameOptionsMiddleware>(headerValue);
		}
	}
}
