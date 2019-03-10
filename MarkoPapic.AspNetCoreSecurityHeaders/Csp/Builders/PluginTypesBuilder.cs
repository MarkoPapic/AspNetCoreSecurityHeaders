using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	/// <summary>
	/// Builder class for Content-Security-Policy header plugin-types directive.
	/// </summary>
	public class PluginTypesBuilder
	{
		private bool noneAllowed;
		private bool allAllowed;
		private readonly ICollection<string> mimeTypesAllowed;

		public PluginTypesBuilder()
		{
			mimeTypesAllowed = new List<string>();
		}

		/// <summary>
		/// Adds the specified MIME type to the directive value.
		/// </summary>
		/// <param name="mimeType">MIME type to be allowed.</param>
		/// <remarks>
		/// See: https://www.iana.org/assignments/media-types/media-types.xhtml
		/// </remarks>
		public PluginTypesBuilder AllowMimeType(string mimeType)
        {
            if (!mimeTypesAllowed.Contains(mimeType))
                mimeTypesAllowed.Add(mimeType);
            return this;
        }

		/// <summary>
		/// Sets the directive value to 'none'.
		/// </summary>
		public PluginTypesBuilder AllowNone()
		{
			noneAllowed = true;
			return this;
		}

		/// <summary>
		/// Sets the directive value to *.
		/// </summary>
		public PluginTypesBuilder AllowAny()
        {
            allAllowed = true;
            return this;
        }

		internal string Build()
		{
			List<string> parts = new List<string>();

			if (noneAllowed)
				parts.Add("'none'");
			else if (allAllowed)
				parts.Add("*");
			else if (mimeTypesAllowed.Count > 0)
				parts.AddRange(mimeTypesAllowed);

			return string.Join(" ", parts);
		}
	}
}
