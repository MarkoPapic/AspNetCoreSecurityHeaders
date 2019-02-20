using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Hpkp
{
	/// <summary>
	/// Used for building <see cref="HpkpOptions"/>.
	/// </summary>
	public class HpkpOptionsBuilder
	{
		private readonly HpkpOptions options;

		internal HpkpOptionsBuilder()
		{
			options = new HpkpOptions();
		}

		/// <summary>
		/// Sets the max-age parameter of the Public-Key-Pins header.
		/// </summary>
		/// <param name="maxAge">Value of the max-age parameter.</param>
		/// <remarks>
		/// Defaults to 5 hours.
		/// See: https://tools.ietf.org/html/rfc7469#section-2.1.2
		/// </remarks>
		public void SetMaxAge(TimeSpan maxAge)
		{
			options.MaxAge = Convert.ToInt64(Math.Floor(maxAge.TotalSeconds));
		}

		/// <summary>
		/// Adds a new pin to the Public-Key-Pins header.
		/// </summary>
		/// <param name="pins">Base64 encoded Subject Public Key Information (SPKI) fingerprints.</param>
		/// <remarks>
		/// See: https://tools.ietf.org/html/rfc7469#section-2.1.1
		/// </remarks>
		public void AddPins(params string[] pins)
		{
			foreach (string pin in pins)
			{
				string item = $"pin-sha256=\"{pin}\"";
				if (!options.Pins.Contains(item))
					options.Pins.Add(item);
			}
		}

		/// <summary>
		/// Adds the includeSubDomains parameter of the Public-Key-Pins header.
		/// </summary>
		/// <remarks>
		/// See: https://tools.ietf.org/html/rfc7469#section-2.1.3
		/// </remarks>
		public void IncludeSubdomains()
		{
			options.IncludeSubdomains = true;
		}

		/// <summary>
		/// Adds a Report-To header and sets the report-to parameter of the Public-Key-Pins header.
		/// </summary>
		/// <param name="optionsAction">A delegate used for setting up the <see cref="ReportGroupOptions"/>.</param>
		public void AddReportingGroup(Action<ReportGroupOptions> optionsAction)
		{
			ReportGroupOptions rg = new ReportGroupOptions();
			optionsAction(rg);
			options.ReportingGroup = rg;
		}

		internal HpkpOptions Build()
		{
			if (options.Pins.Count < 1)
				throw new InvalidOperationException("Unable to set the Public-Key-Pins header without any pins.");
			return options;
		}
	}
}
