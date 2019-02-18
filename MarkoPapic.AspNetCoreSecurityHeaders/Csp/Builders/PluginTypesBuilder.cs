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
			PluginTypesBuilder result = this;
			if (!noneAllowed && !allAllowed)
				mimeTypesAllowed.Add(mimeType);
			return result;
		}

		public PluginTypesBuilder AllowNone()
		{
			noneAllowed = true;
			allAllowed = false;
			mimeTypesAllowed.Clear();
			return this;
		}

		public PluginTypesBuilder AllowAny()
		{
			if (!noneAllowed)
			{
				allAllowed = true;
				mimeTypesAllowed.Clear();
			}
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
