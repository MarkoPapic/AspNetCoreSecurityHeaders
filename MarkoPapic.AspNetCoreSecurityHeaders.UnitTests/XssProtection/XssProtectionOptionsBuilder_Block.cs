using MarkoPapic.AspNetCoreSecurityHeaders.XssProtection;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.XssProtection
{
	public class XssProtectionOptionsBuilder_Block
	{
		[Fact]
		public void Called_FilterEnabledAndBlockModeSet()
		{
			//Arrange
			XssProtectionOptionsBuilder builder = new XssProtectionOptionsBuilder();

			//Act
			builder.Block();

			//Assert
			XssProtectionOptions result = builder.Build();
			Assert.True(result.FilterEnabled);
			Assert.Equal(XssProtectionMode.Block, result.Mode);
		}
	}
}
