using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class FetchDirectiveBuilder_AllowUnsafeEval
	{
		[Fact]
		public void NothingElseCalled_UnsafeEvalReturned()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowUnsafeEval();

			//Assert
			string result = builder.Build();
			Assert.Equal("'unsafe-eval'", result);
		}

		[Fact]
		public void SomethingElseCalled_UnsafeEvalAdded()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowAny();
			builder.AllowUnsafeEval();

			//Assert
			string result = builder.Build();
			Assert.Equal("'unsafe-eval' '*'", result);
		}
	}
}
