using MarkoPapic.AspNetCoreSecurityHeaders.FrameOptions;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.FrameOptions
{
	public class FrameOptionsOptionsBuilder_Deny
	{
		[Fact]
		public void Called_DenyOptionSet()
		{
			//Arrange
			FrameOptionsOptionsBuilder builder = new FrameOptionsOptionsBuilder();

			//Act
			builder.Deny();

			//Assert
			FrameOptionsOptions result = builder.Build();
			Assert.Equal(FrameOption.Deny, result.Option);
		}
	}
}
