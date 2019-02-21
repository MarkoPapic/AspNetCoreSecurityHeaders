using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkoPapic.AspNetCoreSecurityHeaders.FrameOptions
{
	public static class FrameOptionsMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware for adding the X-Frame-Options header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="optionsAction">A delegate used for setting up the <see cref="FrameOptionsOptions"/>.</param>
		public static IApplicationBuilder UseFrameOptions(this IApplicationBuilder app, Action<FrameOptionsOptionsBuilder> optionsAction)
		{
			FrameOptionsOptionsBuilder optionsBuilder = new FrameOptionsOptionsBuilder();
			optionsAction(optionsBuilder);
			FrameOptionsOptions options = optionsBuilder.Build();
			return app.UseMiddleware<FrameOptionsMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for adding the X-Frame-Options header.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="headerValue">Value to be set for X-Frame-Options header.</param>
		/// <returns></returns>
		public static IApplicationBuilder UseFrameOptions(this IApplicationBuilder app, string headerValue)
		{
			return app.UseMiddleware<FrameOptionsMiddleware>(headerValue);
		}
	}
}
