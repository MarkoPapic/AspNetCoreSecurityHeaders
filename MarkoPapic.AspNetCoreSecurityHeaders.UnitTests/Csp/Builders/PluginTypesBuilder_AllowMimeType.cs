using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class PluginTypesBuilder_AllowMimeType
    {
        [Fact]
        public void MimeTypeAllowed_MimeTypeReturned()
        {
            //Arrange
            PluginTypesBuilder builder = new PluginTypesBuilder();

            //Act
            builder.AllowMimeType("img/png");

            //Assert
            string result = builder.Build();
            Assert.Equal("img/png", result);
        }


        [Fact]
        public void DuplicateMimeTypesAllowed_DuplicatesRemoved()
        {
            //Arrange
            PluginTypesBuilder builder = new PluginTypesBuilder();

            //Act
            builder.AllowMimeType("img/png").AllowMimeType("img/png");

            //Assert
            string result = builder.Build();
            Assert.Equal("img/png", result);
        }
    }
}
