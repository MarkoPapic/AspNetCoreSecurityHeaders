using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using Microsoft.AspNetCore.Http;
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
			string csp = options.Content;
			context.Response.Headers.Add("Content-Security-Policy", csp);
			await this.next(context);
		}
	}
}
