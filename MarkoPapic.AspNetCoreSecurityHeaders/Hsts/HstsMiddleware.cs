using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Hsts
{
	public class HstsMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;

		public HstsMiddleware(RequestDelegate next, HstsOptions options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			this.next = next;
			string maxAgeString = Convert.ToInt64(Math.Floor(options.MaxAge.TotalSeconds)).ToString();
			string includeSubdomainsString = options.IncludeSubDomains ? "; includeSubDomains" : string.Empty;
			string preloadString = options.Preload ? "; preload" : string.Empty;
			headerValue = $"{maxAgeString}{includeSubdomainsString}{preloadString}";
		}

		public HstsMiddleware(RequestDelegate next, string headerValue)
		{
			if (headerValue == null)
				throw new ArgumentNullException(nameof(headerValue));

			this.next = next;
			this.headerValue = headerValue;
		}

		public async Task Invoke(HttpContext context)
		{			
			context.Response.Headers.Add("Strict-Transport-Security", headerValue);

			await this.next(context);
		}
	}
}
