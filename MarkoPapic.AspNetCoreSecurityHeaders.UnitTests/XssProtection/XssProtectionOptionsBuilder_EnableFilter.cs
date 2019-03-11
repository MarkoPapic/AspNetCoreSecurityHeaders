using MarkoPapic.AspNetCoreSecurityHeaders.XssProtection;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.XssProtection
{
	public class XssProtectionOptionsBuilder_EnableFilter
	{
		[Fact]
		public void Called_FilterEnabled()
		{
			//Arrange
			XssProtectionOptionsBuilder builder = new XssProtectionOptionsBuilder();

			//Act
			builder.EnableFilter();

			//Assert
			XssProtectionOptions result = builder.Build();
			Assert.True(result.FilterEnabled);
		}
	}
}
