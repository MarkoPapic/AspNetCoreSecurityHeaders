using MarkoPapic.AspNetCoreSecurityHeaders.XFrameOptions;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.XFrameOptions
{
	public class XFrameOptionsOptionsBuilder_Deny
	{
		[Fact]
		public void Called_DenyOptionSet()
		{
			//Arrange
			XFrameOptionsOptionsBuilder builder = new XFrameOptionsOptionsBuilder();

			//Act
			builder.Deny();

			//Assert
			XFrameOptionsOptions result = builder.Build();
			Assert.Equal(XFrameOption.Deny, result.Option);
		}
	}
}
