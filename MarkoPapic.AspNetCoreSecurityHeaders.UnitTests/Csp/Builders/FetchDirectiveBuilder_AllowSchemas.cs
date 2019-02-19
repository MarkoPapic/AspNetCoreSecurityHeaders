using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class FetchDirectiveBuilder_AllowSchemas
	{
		[Fact]
		public void NothingElseCalled_SchemasReturned()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowSchemas("blob:");

			//Assert
			string result = builder.Build();
			Assert.Equal("blob:", result);
		}

		[Fact]
		public void SomethingElseCalled_SchemasIncluded()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowSelf();
			builder.AllowSchemas("blob:");

			//Assert
			string result = builder.Build();
			Assert.Equal("'self' blob:", result);
		}
	}
}
