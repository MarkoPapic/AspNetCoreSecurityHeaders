using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class CspOptionsBuilder_AddReportingGroup
	{
		[Fact]
		public void Invoked_AddedToOptions()
		{
			//Arrange
			CspOptionsBuilder builder = new CspOptionsBuilder();

			//Act
			builder.AddReportingGroup(reportingOptions => {
				reportingOptions.Group = "groupname";
				reportingOptions.Endpoints.Add(new Endpoint("https://example.com/route"));
			});

			//Assert
			CspOptions options = builder.Build();
			Assert.Equal("report-to groupname", options.Content);
			Assert.Equal("groupname", options.ReportingGroup.Group);
			Assert.Equal(1, options.ReportingGroup.Endpoints.Count);
			Assert.Equal("https://example.com/route", options.ReportingGroup.Endpoints[0].Url);
		}
	}
}
