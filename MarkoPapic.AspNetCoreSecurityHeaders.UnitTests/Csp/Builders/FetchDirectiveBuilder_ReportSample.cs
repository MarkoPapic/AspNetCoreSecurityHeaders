using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class FetchDirectiveBuilder_ReportSample
	{
		[Fact]
		public void NothingElseCalled_ReportSampleReturned()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.ReportSample();

			//Assert
			string result = builder.Build();
			Assert.Equal("'report-sample'", result);
		}

		[Fact]
		public void SomethingElseCalled_ReportSampleAdded()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowAny();
			builder.ReportSample();

			//Assert
			string result = builder.Build();
			Assert.Equal("'*' 'report-sample'", result);
		}
	}
}
