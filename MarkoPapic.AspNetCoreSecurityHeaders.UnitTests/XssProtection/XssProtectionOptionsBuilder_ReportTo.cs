using MarkoPapic.AspNetCoreSecurityHeaders.XssProtection;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.XssProtection
{
	public class XssProtectionOptionsBuilder_ReportTo
	{
		[Fact]
		public void Called_FilterEnabledAndReportSet()
		{
			//Arrange
			XssProtectionOptionsBuilder builder = new XssProtectionOptionsBuilder();
			string reportUri = "https://example.com/some-route";

			//Act
			builder.ReportTo(reportUri);

			//Assert
			XssProtectionOptions result = builder.Build();
			Assert.True(result.FilterEnabled);
			Assert.Equal(XssProtectionMode.Report, result.Mode);
			Assert.Equal(reportUri, result.ReportUri);
		}
	}
}
