using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class FetchDirectiveBuilder_AllowAny
	{
		[Fact]
		public void NothingElseCalled_AsteriskReturned()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowAny();

			//Assert
			string result = builder.Build();
			Assert.Equal("'*'", result);
		}

		[Fact]
		public void SomethingElseCalled_AsteriskAdded()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowUnsafeInline();
			builder.AllowHash("sha265-somehash");
			builder.AllowAny();

			//Assert
			string result = builder.Build();
			Assert.Equal("'unsafe-inline' sha265-somehash '*'", result);
		}

		[Fact]
		public void HostsAllowed_HostsIgnored()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowHosts("https://example1.com", "https://example2.com");
			builder.AllowAny();

			//Assert
			string result = builder.Build();
			Assert.Equal("'*'", result);
		}

		[Fact]
		public void SchemasAllowed_SchemasIgnored()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowSchemas("blob:");
			builder.AllowAny();

			//Assert
			string result = builder.Build();
			Assert.Equal("'*'", result);
		}
	}
}
