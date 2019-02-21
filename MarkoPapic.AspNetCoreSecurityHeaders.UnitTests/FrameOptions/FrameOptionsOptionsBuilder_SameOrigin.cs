using MarkoPapic.AspNetCoreSecurityHeaders.FrameOptions;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.FrameOptions
{
	public class FrameOptionsOptionsBuilder_SameOrigin
	{
		[Fact]
		public void Called_SameOriginOptionSet()
		{
			//Arrange
			FrameOptionsOptionsBuilder builder = new FrameOptionsOptionsBuilder();

			//Act
			builder.SameOrigin();

			//Assert
			FrameOptionsOptions result = builder.Build();
			Assert.Equal(FrameOption.SameOrigin, result.Option);
		}
	}
}
