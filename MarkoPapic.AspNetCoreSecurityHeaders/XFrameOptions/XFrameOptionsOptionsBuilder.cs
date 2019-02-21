using System;

namespace MarkoPapic.AspNetCoreSecurityHeaders.XFrameOptions
{
	/// <summary>
	/// Used for building <see cref="XFrameOptionsOptions"/>.
	/// </summary>
	public class XFrameOptionsOptionsBuilder
	{
		private readonly XFrameOptionsOptions options;

		public XFrameOptionsOptionsBuilder()
		{
			options = new XFrameOptionsOptions();
		}

		/// <summary>
		/// Sets the X-Frame-Options header value to deny.
		/// </summary>
		/// <remarks>
		/// This is the default setting.
		/// See: https://tools.ietf.org/html/rfc7034#section-2.1
		/// </remarks>
		public void Deny()
		{
			options.Option = XFrameOption.Deny;
		}

		/// <summary>
		/// Sets the X-Frame-Options header value to sameorigin.
		/// </summary>
		/// <remarks>
		/// See: https://tools.ietf.org/html/rfc7034#section-2.1
		/// </remarks>
		public void SameOrigin()
		{
			options.Option = XFrameOption.SameOrigin;
		}

		/// <summary>
		/// Allows rendering if framed by frame loaded from the specified domain.
		/// </summary>
		/// <param name="domain">Domain for which to allow framing.</param>
		/// <remarks>
		/// See: https://tools.ietf.org/html/rfc7034#section-2.1
		/// </remarks>
		public void AllowFrom(string domain)
		{
			if (domain == null)
				throw new ArgumentNullException(nameof(domain));

			options.Option = XFrameOption.AllowFromDomain;
			options.AllowedDomain = domain;
		}

		internal XFrameOptionsOptions Build()
		{
			return options;
		}
	}
}
