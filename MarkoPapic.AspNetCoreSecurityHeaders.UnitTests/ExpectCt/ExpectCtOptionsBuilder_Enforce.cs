using MarkoPapic.AspNetCoreSecurityHeaders.ExpectCt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.ExpectCt
{
	public class ExpectCtOptionsBuilder_Enforce
	{
		[Fact]
		public void Called_EnforceSet()
		{
			//Arrange
			ExpectCtOptionsBuilder builder = new ExpectCtOptionsBuilder();

			//Act
			builder.Enforce();

			//Assert
			ExpectCtOptions result = builder.Build();
			Assert.True(result.Enforce);
		}
	}
}
