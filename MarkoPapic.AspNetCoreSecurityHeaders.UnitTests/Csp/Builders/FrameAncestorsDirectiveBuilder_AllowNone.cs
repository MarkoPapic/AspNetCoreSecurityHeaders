using System;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class FrameAncestorsDirectiveBuilder_AllowNone
    {
        [Fact]
        public void NothingElseCalled_NoneReturned()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

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
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

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

        [Fact]
        public void DuplicateNoneAllowed_DuplicatesRemoved()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowNone().AllowNone();

            //Assert
            string result = builder.Build();
            Assert.Equal("'none'", result);
        }
    }
}
