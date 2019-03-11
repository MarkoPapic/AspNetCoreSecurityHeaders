using MarkoPapic.AspNetCoreSecurityHeaders.ExpectCt;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.ExpectCt
{
	public class ExpectCtOptionsBuilder_SetReportUri
	{
		[Fact]
		public void Called_EnforceSet()
		{
			//Arrange
			ExpectCtOptionsBuilder builder = new ExpectCtOptionsBuilder();

			//Act
			string reportUri = "https://example.com/some-route";
			builder.SetReportUri(reportUri);

			//Assert
			ExpectCtOptions result = builder.Build();
			Assert.Equal(reportUri, result.ReportUri);
		}
	}
}
