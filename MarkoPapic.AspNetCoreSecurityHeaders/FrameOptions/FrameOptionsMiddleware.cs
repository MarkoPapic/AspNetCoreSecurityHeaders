using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.FrameOptions
{
	public class FrameOptionsMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;

		public FrameOptionsMiddleware(RequestDelegate next, FrameOptionsOptions options)
		{
			if (options == null)
				throw new ArgumentNullException(nameof(options));

			this.next = next;

			switch (options.Option)
			{
				case FrameOption.Deny:
					headerValue = "deny";
					break;
				case FrameOption.SameOrigin:
					headerValue = "sameorigin";
					break;
				case FrameOption.AllowFromDomain:
					headerValue = $"allow-from: {options.AllowedDomain}";
					break;
			}
		}

		public FrameOptionsMiddleware(RequestDelegate next, string headerValue)
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
