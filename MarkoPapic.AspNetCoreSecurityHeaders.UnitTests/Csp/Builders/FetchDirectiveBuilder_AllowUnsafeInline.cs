using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class FetchDirectiveBuilder_AllowUnsafeInline
	{
		[Fact]
		public void NothingElseCalled_UnsafeInlineReturned()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowUnsafeInline();

			//Assert
			string result = builder.Build();
			Assert.Equal("'unsafe-inline'", result);
		}

		[Fact]
		public void SomethingElseCalled_UnsafeInlineAdded()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowAny();
			builder.AllowUnsafeInline();

			//Assert
			string result = builder.Build();
			Assert.Equal("'unsafe-inline' '*'", result);
		}

        [Fact]
        public void DuplicateUnsafeInlineAllowed_DuplicatesRemoved()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

            //Act
            builder.AllowUnsafeInline().AllowUnsafeInline();

            //Assert
            string result = builder.Build();
            Assert.Equal("'unsafe-inline'", result);
        }
    }
}
