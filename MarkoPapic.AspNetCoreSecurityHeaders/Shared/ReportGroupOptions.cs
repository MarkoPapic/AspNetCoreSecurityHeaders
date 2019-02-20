using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders
{
	public class ReportGroupOptions
	{
		public ReportGroupOptions()
		{
			Endpoints = new List<ReportGroupEndpoint>();
		}

		[JsonProperty(PropertyName = "group")]
		public string Group { get; set; }
		[JsonProperty(PropertyName = "max_age")]
		public long MaxAge { get; set; }
		[JsonProperty(PropertyName = "include_subdomains")]
		public bool IncludeSubdomains { get; set; }
		[JsonProperty(PropertyName = "endpoints")]
		public IList<ReportGroupEndpoint> Endpoints { get; set; }
	}

	public class ReportGroupEndpoint
	{
		public ReportGroupEndpoint(string url)
		{
			Url = url;
		}

		public ReportGroupEndpoint(string url, int priority, int weight)
		{
			Url = url;
			Priority = priority;
			Weight = weight;
		}

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }
		[JsonProperty(PropertyName = "priority")]
		public int Priority { get; set; }
		[JsonProperty(PropertyName = "weight")]
		public int Weight { get; set; }
	}
}
