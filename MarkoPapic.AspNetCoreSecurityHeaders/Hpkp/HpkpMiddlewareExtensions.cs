using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Hpkp
{
	public static class HpkpMiddlewareExtensions
	{
		/// <summary>
		/// Adds middleware for using HPKP, which adds the Public-Key-Pins header.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
		/// <param name="optionsAction">A delegate used for setting up the <see cref="HpkpOptionsBuilder"/>.</param>
		public static IApplicationBuilder UseHpkp(this IApplicationBuilder app, Action<HpkpOptionsBuilder> optionsAction)
		{
			HpkpOptionsBuilder optionsBuilder = new HpkpOptionsBuilder();
			optionsAction(optionsBuilder);
			HpkpOptions options = optionsBuilder.Build();
			return app.UseMiddleware<HpkpMiddleware>(options);
		}

		/// <summary>
		/// Adds middleware for using HPKP, which adds the Public-Key-Pins header.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="headerValue">Value to be set for Public-Key-Pins header.</param>
		/// <returns></returns>
		public static IApplicationBuilder UseHpkp(this IApplicationBuilder app, string headerValue)
		{
			return app.UseMiddleware<HpkpMiddleware>(headerValue);
		}
	}
}
