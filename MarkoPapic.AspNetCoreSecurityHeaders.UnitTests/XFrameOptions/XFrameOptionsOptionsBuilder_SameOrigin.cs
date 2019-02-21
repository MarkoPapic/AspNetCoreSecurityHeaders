using MarkoPapic.AspNetCoreSecurityHeaders.XFrameOptions;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.XFrameOptions
{
	public class XFrameOptionsOptionsBuilder_SameOrigin
	{
		[Fact]
		public void Called_SameOriginOptionSet()
		{
			//Arrange
			XFrameOptionsOptionsBuilder builder = new XFrameOptionsOptionsBuilder();

			//Act
			builder.SameOrigin();

			//Assert
			XFrameOptionsOptions result = builder.Build();
			Assert.Equal(XFrameOption.SameOrigin, result.Option);
		}
	}
}
