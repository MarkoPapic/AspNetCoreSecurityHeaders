using MarkoPapic.AspNetCoreSecurityHeaders.XssProtection;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.XssProtection
{
	public class XssProtectionOptionsBuilder_DisableFilter
	{
		[Fact]
		public void Called_FilterDisabled()
		{
			//Arrange
			XssProtectionOptionsBuilder builder = new XssProtectionOptionsBuilder();

			//Act
			builder.DisableFilter();

			//Assert
			XssProtectionOptions result = builder.Build();
			Assert.False(result.FilterEnabled);
		}
	}
}
