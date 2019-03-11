using Microsoft.AspNetCore.Builder;
using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.ExpectCt
{
	/// <summary>
	/// Extension methods for the Expect CT middleware.
	/// </summary>
	public static class ExpectCtMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware for using ExpectCT, which adds the Expect-CT header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="optionsAction">A delegate used for setting up the <see cref="ExpectCtOptionsBuilder"/>.</param>
		public static IApplicationBuilder UseExpectCt(this IApplicationBuilder app, Action<ExpectCtOptionsBuilder> optionsAction)
		{
			ExpectCtOptionsBuilder builder = new ExpectCtOptionsBuilder();
			optionsAction(builder);
			ExpectCtOptions options = builder.Build();
			return app.UseMiddleware<ExpectCtMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for using ExpectCT, which adds the Expect-CT header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="headerValue">Value to be set for Expect-CT header.</param>
		/// <returns></returns>
		public static IApplicationBuilder UseExpectCt(this IApplicationBuilder app, string headerValue)
		{
			return app.UseMiddleware<ExpectCtMiddleware>(headerValue);
		}
	}
}
