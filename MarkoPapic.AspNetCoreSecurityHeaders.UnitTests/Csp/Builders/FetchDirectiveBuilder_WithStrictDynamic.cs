using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class FetchDirectiveBuilder_WithStrictDynamic
	{
		[Fact]
		public void NothingElseCalled_StrictDynamicReturned()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.WithStrictDynamic();

			//Assert
			string result = builder.Build();
			Assert.Equal("'strict-dynamic'", result);
		}

		[Fact]
		public void SomethingElseCalled_StrictDynamicAdded()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowAny();
			builder.WithStrictDynamic();

			//Assert
			string result = builder.Build();
			Assert.Equal("'strict-dynamic' '*'", result);
		}

        [Fact]
        public void DuplicateStrictDynamicCalled_DuplicatesRemoved()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

            //Act
            builder.WithStrictDynamic().WithStrictDynamic();

            //Assert
            string result = builder.Build();
            Assert.Equal("'strict-dynamic'", result);
        }
    }
}
