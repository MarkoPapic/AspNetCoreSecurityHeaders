using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class FetchDirectiveBuilder_AllowHosts
	{
		[Fact]
		public void NothingElseCalled_HostsReturned()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowHosts("https://example1.com");

			//Assert
			string result = builder.Build();
			Assert.Equal("https://example1.com", result);
		}

		[Fact]
		public void SomethingElseCalled_HostsIncluded()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowSelf();
			builder.AllowHosts("https://example1.com");

			//Assert
			string result = builder.Build();
			Assert.Equal("'self' https://example1.com", result);
		}
	}
}
