using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.ExpectCt
{
	public class ExpectCtMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;

		public ExpectCtMiddleware(RequestDelegate next, ExpectCtOptions options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			this.next = next;

			List<string> parts = new List<string>();
			if (options.ReportUri != null) parts.Add($"report-uri=\"{options.ReportUri}\"");
			if (options.Enforce) parts.Add("enforce");
			parts.Add($"max-age={options.MaxAge}");
			headerValue = string.Join(", ", parts);
		}

		public ExpectCtMiddleware(RequestDelegate next, string headerValue)
		{
			if (headerValue == null)
				throw new ArgumentNullException(nameof(headerValue));

			this.next = next;
			this.headerValue = headerValue;
		}

		public async Task Invoke(HttpContext context)
		{
			context.Response.Headers.Add("Expect-CT", headerValue);

			await this.next(context);
		}
	}
}
