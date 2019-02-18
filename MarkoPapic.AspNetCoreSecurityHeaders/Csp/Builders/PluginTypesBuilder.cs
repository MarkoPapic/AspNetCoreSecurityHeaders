using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	public class PluginTypesBuilder
	{
		private bool noneAllowed;
		private bool allAllowed;
		private readonly ICollection<string> mimeTypesAllowed;

		public PluginTypesBuilder()
		{
			mimeTypesAllowed = new List<string>();
		}

        public PluginTypesBuilder AllowMimeType(string mimeType)
        {
            mimeTypesAllowed.Add(mimeType);
            return this;
        }

		public PluginTypesBuilder AllowNone()
		{
			noneAllowed = true;
			return this;
		}

        public PluginTypesBuilder AllowAny()
        {
            allAllowed = true;
            return this;
        }

		public string Build()
		{
			List<string> parts = new List<string>();

			if (noneAllowed)
				parts.Add("'none'");
			else if (allAllowed)
				parts.Add("'*'");
			else if (mimeTypesAllowed.Count > 0)
				parts.AddRange(mimeTypesAllowed);

			return string.Join(" ", parts);
		}
	}
}
