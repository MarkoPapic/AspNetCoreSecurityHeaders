using MarkoPapic.AspNetCoreSecurityHeaders.Hpkp;
using System;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Hpkp
{
	public class HpkpOptionsBuilder_SetMaxAge
	{
		[Theory]
		[InlineData(0, 0)]
		[InlineData(1, 3600)]
		[InlineData(50, 180000)]
		public void Called_MaxAgeSet(int maxAgeHours, int expected)
		{
			//Arrange
			HpkpOptionsBuilder builder = new HpkpOptionsBuilder();

			//Act
			builder.AddPins("==somepinvalue").SetMaxAge(TimeSpan.FromHours(maxAgeHours));

			//Assert
			HpkpOptions result = builder.Build();
			Assert.Equal(expected, result.MaxAge);
		}
	}
}
