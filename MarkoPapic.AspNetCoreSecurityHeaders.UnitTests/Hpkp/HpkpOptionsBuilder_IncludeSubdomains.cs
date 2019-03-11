using MarkoPapic.AspNetCoreSecurityHeaders.Hpkp;
using System;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Hpkp
{
	public class HpkpOptionsBuilder_IncludeSubdomains
	{
		[Fact]
		public void Called_IncludeSubdomainsSet()
		{
			//Arrange
			HpkpOptionsBuilder builder = new HpkpOptionsBuilder();

			//Act
			builder.AddPins("==somepinvalue").IncludeSubdomains();

			//Assert
			HpkpOptions result = builder.Build();
			Assert.True(result.IncludeSubdomains);
		}
	}
}
