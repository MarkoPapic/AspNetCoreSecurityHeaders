using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Hpkp
{
	public class HpkpMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;
		private readonly string reportingGroupJson;

		public HpkpMiddleware(RequestDelegate next, HpkpOptions options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			this.next = next;

			List<string> parts = new List<string>();
			parts.AddRange(options.Pins);
			if (options.ReportingGroup != null)
			{
				string rgJson = JsonConvert.SerializeObject(options.ReportingGroup);
				this.reportingGroupJson = rgJson;
				parts.Add($"report-to {options.ReportingGroup.Group}");
			}
			parts.Add($"max-age={options.MaxAge}");
			if (options.IncludeSubdomains) parts.Add("includeSubDomains");
			headerValue = string.Join("; ", parts);
		}

		public HpkpMiddleware(RequestDelegate next, string headerValue)
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
				context.Response.Headers.Add("Public-Key-Pins", headerValue);

			await this.next(context);
		}
	}
}
