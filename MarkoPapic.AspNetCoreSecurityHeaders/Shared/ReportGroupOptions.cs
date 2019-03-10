using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders
{
	/// <summary>
	/// Options for the Report-To header report group.
	/// </summary>
	public class ReportGroupOptions
	{
		public ReportGroupOptions()
		{
			Endpoints = new List<ReportGroupEndpoint>();
		}

		/// <summary>
		/// Sets the 'group' member of the Report-To header JSON.
		/// </summary>
		/// <remarks>
		/// See: https://w3c.github.io/reporting/#id-member
		/// </remarks>
		[JsonProperty(PropertyName = "group")]
		public string Group { get; set; }

		/// <summary>
		/// Sets the 'max_age' member of the Report-To header JSON value.
		/// </summary>
		/// <remarks>
		/// See: https://w3c.github.io/reporting/#max-age-member
		/// </remarks>
		[JsonProperty(PropertyName = "max_age")]
		public long MaxAge { get; set; }

		/// <summary>
		/// Sets the 'include_subdomain' member of the Report-To header JSON value.
		/// </summary>
		/// <remarks>
		/// See: https://w3c.github.io/reporting/#include-subdomains-member
		/// </remarks>
		[JsonProperty(PropertyName = "include_subdomains")]
		public bool IncludeSubdomains { get; set; }

		/// <summary>
		/// Sets the 'endpoints' member of the Report-To header JSON value.
		/// </summary>
		/// <remarks>
		/// See: https://w3c.github.io/reporting/#endpoints-member
		/// </remarks>
		[JsonProperty(PropertyName = "endpoints")]
		public IList<ReportGroupEndpoint> Endpoints { get; set; }
	}

	/// <summary>
	/// Represents a model for the 'enpoints' member of the Report-To header JSON value.
	/// </summary>
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

		/// <summary>
		/// Sets the 'url' member of the element of the 'endpoints' member of the Report-To header JSON value.
		/// </summary>
		/// See: https://w3c.github.io/reporting/#endpoints-url-member
		/// </remarks>
		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		/// <summary>
		/// Sets the 'priority' member of the element of the 'endpoints' member of the Report-To header JSON value.
		/// </summary>
		/// See: https://w3c.github.io/reporting/#endpoints-priority-member
		/// </remarks>
		[JsonProperty(PropertyName = "priority")]
		public int Priority { get; set; }

		/// <summary>
		/// Sets the 'weight' member of the element of the 'endpoints' member of the Report-To header JSON value.
		/// </summary>
		/// See: https://w3c.github.io/reporting/#endpoints-weight-member
		/// </remarks>
		[JsonProperty(PropertyName = "weight")]
		public int Weight { get; set; }
	}
}
