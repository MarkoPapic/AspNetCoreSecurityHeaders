using MarkoPapic.AspNetCoreSecurityHeaders.FrameOptions;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.FrameOptions
{
	public class FrameOptionsOptionsBuilder_AllowFrom
	{
		[Fact]
		public void Called_DomainOptionSet()
		{
			//Arrange
			FrameOptionsOptionsBuilder builder = new FrameOptionsOptionsBuilder();
			string domain = "example.com";

			//Act
			builder.AllowFrom(domain);

			//Assert
			FrameOptionsOptions result = builder.Build();
			Assert.Equal(FrameOption.AllowFromDomain, result.Option);
			Assert.Equal(domain, result.AllowedDomain);
		}
	}
}
