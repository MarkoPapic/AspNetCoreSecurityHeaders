using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.XssProtection
{
	public class XssProtectionMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;

		public XssProtectionMiddleware(RequestDelegate next, XssProtectionOptions options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			this.next = next;

			headerValue = CreateHeaderValue(options);
		}

		public XssProtectionMiddleware(RequestDelegate next, string headerValue)
		{
			if (headerValue == null)
				throw new ArgumentNullException(nameof(headerValue));

			this.next = next;
			this.headerValue = headerValue;
		}

		public async Task Invoke(HttpContext context)
		{
			if (headerValue != null)
				context.Response.Headers.Add("X-XSS-Protection", headerValue);

			await this.next(context);
		}

		private string CreateHeaderValue(XssProtectionOptions options)
		{
			string result = null;

			if (options.FilterEnabled)
			{
				switch (options.Mode)
				{
					case XssProtectionMode.None:
						result = "1";
						break;
					case XssProtectionMode.Block:
						result = "1; mode=block";
						break;
					case XssProtectionMode.Report:
						result = $"1; report={options.ReportUri}";
						break;
				}
			}
			else
			{
				result = "0";
			}

			return result;
		}
	}
}
