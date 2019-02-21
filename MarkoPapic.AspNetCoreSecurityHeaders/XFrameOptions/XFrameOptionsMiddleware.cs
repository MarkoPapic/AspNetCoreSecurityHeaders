using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.XFrameOptions
{
	public class XFrameOptionsMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;

		public XFrameOptionsMiddleware(RequestDelegate next, XFrameOptionsOptions options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			this.next = next;

			switch (options.Option)
			{
				case XFrameOption.Deny:
					headerValue = "deny";
					break;
				case XFrameOption.SameOrigin:
					headerValue = "sameorigin";
					break;
				case XFrameOption.AllowFromDomain:
					headerValue = $"allow-from: {options.AllowedDomain}";
					break;
			}
		}

		public XFrameOptionsMiddleware(RequestDelegate next, string headerValue)
		{
			if (headerValue == null)
				throw new ArgumentNullException(nameof(headerValue));

			this.next = next;
			this.headerValue = headerValue;
		}

		public async Task Invoke(HttpContext context)
		{
			if (headerValue != null)
				context.Response.Headers.Add("X-Frame-Options", headerValue);

			await this.next(context);
		}
	}
}
