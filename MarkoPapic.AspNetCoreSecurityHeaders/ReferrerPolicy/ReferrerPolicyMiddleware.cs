using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.ReferrerPolicy
{
	public class ReferrerPolicyMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;

		public ReferrerPolicyMiddleware(RequestDelegate next, ReferrerPolicyOptions option)
		{
			this.next = next;

			switch (option)
			{
				case ReferrerPolicyOptions.NoReferrerWhenDowngrade:
					headerValue = "no-referrer-when-downgrade";
					break;
				case ReferrerPolicyOptions.NoReferrer:
					headerValue = "no-referrer";
					break;
				case ReferrerPolicyOptions.Origin:
					headerValue = "origin";
					break;
				case ReferrerPolicyOptions.OriginWhenCrossOrigin:
					headerValue = "origin-when-cross-origin";
					break;
				case ReferrerPolicyOptions.SameOrigin:
					headerValue = "same-origin";
					break;
				case ReferrerPolicyOptions.StrictOrigin:
					headerValue = "strict-origin";
					break;
				case ReferrerPolicyOptions.StrictOriginWhenCrossOrigin:
					headerValue = "strict-origin-when-cross-origin";
					break;
				case ReferrerPolicyOptions.UnsafeUrl:
					headerValue = "unsafe-url";
					break;
			}
		}

		public ReferrerPolicyMiddleware(RequestDelegate next, string headerValue)
		{
			this.next = next;

			this.headerValue = headerValue;
		}

		public async Task Invoke(HttpContext context)
		{
			context.Response.Headers.Add("Referrer-Policy", headerValue);

			await this.next(context);
		}
	}
}
