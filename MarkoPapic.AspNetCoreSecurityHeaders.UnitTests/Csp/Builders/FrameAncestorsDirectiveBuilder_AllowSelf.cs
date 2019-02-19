using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class FrameAncestorsDirectiveBuilder_AllowSelf
    {
        [Fact]
        public void NothingElseCalled_SelfReturned()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

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
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

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
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowSelf().AllowSelf();

            //Assert
            string result = builder.Build();
            Assert.Equal("'self'", result);
        }
    }
}
