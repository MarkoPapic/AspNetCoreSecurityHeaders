using System;
using System.Collections.Generic;
using System.Text;

namespace MarkoPapic.AspNetCoreSecurityHeaders.XssProtection
{
	/// <summary>
	/// Used for building <see cref="XssProtectionOptions"/>.
	/// </summary>
	public class XssProtectionOptionsBuilder
	{
		private readonly XssProtectionOptions options;

		internal XssProtectionOptionsBuilder()
		{
			options = new XssProtectionOptions();
		}

		/// <summary>
		/// Sets the X-XSS-Protection header value to 0.
		/// </summary>
		public void DisableFilter()
		{
			options.FilterEnabled = false;
		}

		/// <summary>
		/// Sets the X-XSS-Protection header value to 1.
		/// </summary>
		/// <remarks>
		/// This is the default setting.
		/// </remarks>
		public void EnableFilter()
		{
			options.FilterEnabled = true;
		}

		/// <summary>
		/// Sets the X-XSS-Protection header value to 1; mode=block.
		/// </summary>
		public void Block()
		{
			EnableFilter();
			options.Mode = XssProtectionMode.Block;
		}

		/// <summary>
		/// Sets the X-XSS-Protection header value to 1; report=<paramref name="reportUri"/>.
		/// </summary>
		/// <param name="reportUri">URI the report should be sent to.</param>
		public void ReportTo(string reportUri)
		{
			EnableFilter();
			options.Mode = XssProtectionMode.Report;
			options.ReportUri = reportUri;
		}

		internal XssProtectionOptions BuildDefault()
		{
			EnableFilter();
			return options;
		}

		internal XssProtectionOptions Build()
		{
			return options;
		}
	}
}
