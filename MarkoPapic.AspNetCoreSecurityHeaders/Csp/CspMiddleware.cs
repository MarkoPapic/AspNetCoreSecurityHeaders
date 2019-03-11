using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp
{
	public class CspMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;
		private readonly string reportingGroupJson;

		public CspMiddleware(RequestDelegate next, CspOptions options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			this.next = next;
			if (!string.IsNullOrWhiteSpace(options.Content))
			{
				headerValue = options.Content;
				if (options.ReportingGroup != null)
				{
					string rgJson = JsonConvert.SerializeObject(options.ReportingGroup);
					this.reportingGroupJson = rgJson;
				}
			}
		}

		public CspMiddleware(RequestDelegate next, string headerValue)
		{
			if (headerValue == null)
				throw new ArgumentNullException(nameof(headerValue));

			this.next = next;
			this.headerValue = headerValue;
		}

		public async Task Invoke(HttpContext context)
		{
			if (reportingGroupJson != null)
				context.Response.Headers.Add("Report-To", reportingGroupJson);
			if (headerValue != null)
				context.Response.Headers.Add("Content-Security-Policy", headerValue);

			await this.next(context);
		}
	}
}
