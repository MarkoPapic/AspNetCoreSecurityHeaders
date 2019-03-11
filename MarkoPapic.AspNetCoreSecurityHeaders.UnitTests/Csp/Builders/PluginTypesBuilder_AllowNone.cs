using System;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class PluginTypesBuilder_AllowNone
    {
        [Fact]
        public void NothingElseCalled_NoneReturned()
        {
            //Arrange
            PluginTypesBuilder builder = new PluginTypesBuilder();

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
            PluginTypesBuilder builder = new PluginTypesBuilder();

            //Act
            builder.AllowMimeType("img/png");
            builder.AllowNone();
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'none'", result);
        }

        [Fact]
        public void DuplicateNoneAllowed_DuplicatesRemoved()
        {
            //Arrange
            PluginTypesBuilder builder = new PluginTypesBuilder();

            //Act
            builder.AllowNone().AllowNone();

            //Assert
            string result = builder.Build();
            Assert.Equal("'none'", result);
        }
    }
}
