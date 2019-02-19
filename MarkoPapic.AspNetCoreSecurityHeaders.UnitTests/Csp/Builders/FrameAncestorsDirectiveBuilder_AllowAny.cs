using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class FrameAncestorsDirectiveBuilder_AllowAny
    {
        [Fact]
        public void NothingElseCalled_AsteriskReturned()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'*'", result);
        }

        [Fact]
        public void HostsAllowed_HostsIgnored()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

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
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowSchemas("blob:");
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'*'", result);
        }

        [Fact]
        public void DuplicateAnyAllowed_DuplicatesRemoved()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowAny().AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'*'", result);
        }
    }
}
