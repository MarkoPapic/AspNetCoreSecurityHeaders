using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MarkoPapic.AspNetCoreSecurityHeaders.CrossDomainPolicies
{	
	public class CrossDomainPoliciesMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string headerValue;

		public CrossDomainPoliciesMiddleware(RequestDelegate next, CrossDomainPoliciesOptions option)
		{
			this.next = next;

			switch (option)
			{
				case CrossDomainPoliciesOptions.None:
					headerValue = "none";
					break;
				case CrossDomainPoliciesOptions.MasterOnly:
					headerValue = "master-only";
					break;
				case CrossDomainPoliciesOptions.ByContentType:
					headerValue = "by-content-type";
					break;
				case CrossDomainPoliciesOptions.ByFtpFilename:
					headerValue = "by-ftp-filename";
					break;
				case CrossDomainPoliciesOptions.All:
					headerValue = "all";
					break;
			}
		}

		public CrossDomainPoliciesMiddleware(RequestDelegate next, string headerValue)
		{
			this.next = next;

			this.headerValue = headerValue;
		}

		public async Task Invoke(HttpContext context)
		{
			context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", headerValue);

			await this.next(context);
		}
	}
}
