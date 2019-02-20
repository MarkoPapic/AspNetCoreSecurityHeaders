using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp
{
	public class CspMiddleware
	{
		private readonly RequestDelegate next;
		private readonly CspOptions options;

		public CspMiddleware(RequestDelegate next, CspOptions options)
		{
			this.next = next;
			this.options = options;
		}

		public async Task Invoke(HttpContext context)
		{
			if (!string.IsNullOrWhiteSpace(options.Content))
			{
				if (options.ReportingGroup != null)
				{
					string reportGroupJson = JsonConvert.SerializeObject(options.ReportingGroup);
					context.Response.Headers.Add("Report-To", reportGroupJson);
				}
				context.Response.Headers.Add("Content-Security-Policy", options.Content);
			}
			await this.next(context);
		}
	}
}
