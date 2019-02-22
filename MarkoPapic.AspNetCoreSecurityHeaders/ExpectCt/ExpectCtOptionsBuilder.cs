using System;
using System.Collections.Generic;
using System.Text;

namespace MarkoPapic.AspNetCoreSecurityHeaders.ExpectCt
{
	public class ExpectCtOptionsBuilder
	{
		private readonly ExpectCtOptions options;

		internal ExpectCtOptionsBuilder()
		{
			options = new ExpectCtOptions();
		}

		/// <summary>
		/// Sets the max-age parameter of the Expect-CT header.
		/// </summary>
		/// <param name="maxAge">Value of the max-age parameter.</param>
		/// <remarks>
		/// See: https://tools.ietf.org/html/draft-ietf-httpbis-expect-ct-07#section-2.1.3
		/// </remarks>
		public ExpectCtOptionsBuilder SetMaxAge(TimeSpan maxAge)
		{
			options.MaxAge = Convert.ToInt64(Math.Floor(maxAge.TotalSeconds));
			return this;
		}

		/// <summary>
		/// Adds the enforce parameter of the Expect-CT header.
		/// </summary>
		/// <remarks>
		/// See: https://tools.ietf.org/html/draft-ietf-httpbis-expect-ct-07#section-2.1.2
		/// </remarks>
		public ExpectCtOptionsBuilder Enforce()
		{
			options.Enforce = true;
			return this;
		}

		/// <summary>
		/// Adds the report-uri parameter of the Expect-CT header.
		/// </summary>
		/// <param name="reportUri">The URI to report to.</param>
		/// <remarks>
		/// See: https://tools.ietf.org/html/draft-ietf-httpbis-expect-ct-07#section-2.1.1
		/// </remarks>
		public ExpectCtOptionsBuilder SetReportUri(string reportUri)
		{
			options.ReportUri = reportUri;
			return this;
		}

		internal ExpectCtOptions Build()
		{
			return options;
		}
	}
}
