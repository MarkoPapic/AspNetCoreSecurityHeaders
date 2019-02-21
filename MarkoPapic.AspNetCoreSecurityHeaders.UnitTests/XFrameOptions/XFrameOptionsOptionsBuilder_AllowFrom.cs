using MarkoPapic.AspNetCoreSecurityHeaders.XFrameOptions;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.XFrameOptions
{
	public class XFrameOptionsOptionsBuilder_AllowFrom
	{
		[Fact]
		public void Called_DomainOptionSet()
		{
			//Arrange
			XFrameOptionsOptionsBuilder builder = new XFrameOptionsOptionsBuilder();
			string domain = "example.com";

			//Act
			builder.AllowFrom(domain);

			//Assert
			XFrameOptionsOptions result = builder.Build();
			Assert.Equal(XFrameOption.AllowFromDomain, result.Option);
			Assert.Equal(domain, result.AllowedDomain);
		}
	}
}
