using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.ContentTypeOptions
{
	public class NoSniffMiddleware
	{
		private readonly RequestDelegate next;

		public NoSniffMiddleware(RequestDelegate next) {
			this.next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

			await this.next(context);
		}
	}
}
