using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class FetchDirectiveBuilder_AllowNone
    {
        [Fact]
        public void NothingElseCalled_NoneReturned()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

            //Act
            builder.AllowNone();

            //Assert
            string result = builder.Build();
            Assert.Equal("'none'", result);
        }

        [Fact]
        public void SomethingElseCalled_OnlyNoneReturned()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();

            //Act
            builder.AllowSelf();
            builder.AllowHosts("https://example1.com", "https://example2.com");
            builder.AllowNone();
            builder.AllowSchemas("blob:");
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'none'", result);
        }
    }
}
