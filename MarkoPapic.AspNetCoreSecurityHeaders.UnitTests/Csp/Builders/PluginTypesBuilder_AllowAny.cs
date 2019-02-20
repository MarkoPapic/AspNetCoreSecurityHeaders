using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class PluginTypesBuilder_AllowAny
    {
        [Fact]
        public void NothingElseCalled_AsteriskReturned()
        {
            //Arrange
            PluginTypesBuilder builder = new PluginTypesBuilder();

            //Act
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("*", result);
        }

        [Fact]
        public void MimeTypesAllowed_MimeTypesIgnored()
        {
            //Arrange
            PluginTypesBuilder builder = new PluginTypesBuilder();

            //Act
            builder.AllowMimeType("img/png").AllowMimeType("img/jpg");
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("*", result);
        }

        [Fact]
        public void DuplicateAnyAllowed_DuplicatesRemoved()
        {
            //Arrange
            PluginTypesBuilder builder = new PluginTypesBuilder();

            //Act
            builder.AllowAny().AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("*", result);
        }
    }
}
