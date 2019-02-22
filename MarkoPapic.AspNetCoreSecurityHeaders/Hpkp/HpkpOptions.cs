using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Hpkp
{
	public class HpkpOptions
	{
		internal HpkpOptions() { }

		internal ICollection<string> Pins { get; set; } = new List<string>();
		internal long MaxAge { get; set; } = 18000;
		internal bool IncludeSubdomains { get; set; }
		internal ReportGroupOptions ReportingGroup { get; set; }
	}
}
