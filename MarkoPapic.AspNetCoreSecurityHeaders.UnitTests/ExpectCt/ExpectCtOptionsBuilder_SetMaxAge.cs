using MarkoPapic.AspNetCoreSecurityHeaders.ExpectCt;
using System;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.ExpectCt
{
	public class ExpectCtOptionsBuilder_SetMaxAge
	{
		[Theory]
		[InlineData(0, 0)]
		[InlineData(1, 3600)]
		[InlineData(50, 180000)]
		public void Called_MaxAgeSet(int maxAgeHours, int expected)
		{
			//Arrange
			ExpectCtOptionsBuilder builder = new ExpectCtOptionsBuilder();

			//Act
			builder.SetMaxAge(TimeSpan.FromHours(maxAgeHours));

			//Assert
			ExpectCtOptions result = builder.Build();
			Assert.Equal(expected, result.MaxAge);
		}
	}
}
