using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
	public class FetchDirectiveBuilder_AllowSelf
	{
		[Fact]
		public void NothingElseCalled_SelfReturned()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowSelf();

			//Assert
			string result = builder.Build();
			Assert.Equal("'self'", result);
		}

		[Fact]
		public void SomethingElseCalled_SelfIncluded()
		{
			//Arrange
			FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

			//Act
			builder.AllowSelf();
			builder.AllowHosts("https://example1.com", "https://example2.com");
			builder.AllowSchemas("blob:");

			//Assert
			string result = builder.Build();
			Assert.Equal("'self' https://example1.com https://example2.com blob:", result);
		}

        [Fact]
        public void DuplicateSelfAllowed_DuplicatesRemoved()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

            //Act
            builder.AllowSelf().AllowSelf();

            //Assert
            string result = builder.Build();
            Assert.Equal("'self'", result);
        }
    }
}
