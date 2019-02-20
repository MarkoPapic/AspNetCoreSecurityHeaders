using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options
{
	public class ReportGroupOptions
	{
		public ReportGroupOptions()
		{
			Endpoints = new List<Endpoint>();
		}
		//TODO: Customize JSON field names
		public string Group { get; set; }
		public long MaxAge { get; set; }
		public bool IncludeSubdomains { get; set; }
		public IList<Endpoint> Endpoints { get; set; }
	}

	public class Endpoint
	{
		public Endpoint(string url)
		{
			Url = url;
		}

		public Endpoint(string url, int priority, int weight)
		{
			Url = url;
			Priority = priority;
			Weight = weight;
		}

		public string Url { get; set; }
		public int Priority { get; set; }
		public int Weight { get; set; }
	}
}
