using System;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class FrameAncestorsDirectiveBuilder_AllowHosts
    {
        [Fact]
        public void NothingElseCalled_HostsReturned()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowHosts("https://example1.com");

            //Assert
            string result = builder.Build();
            Assert.Equal("https://example1.com", result);
        }

        [Fact]
        public void SomethingElseCalled_HostsIncluded()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowSelf();
            builder.AllowHosts("https://example1.com");

            //Assert
            string result = builder.Build();
            Assert.Equal("'self' https://example1.com", result);
        }

        [Fact]
        public void DuplicateHostsAllowed_DuplicatesRemoved()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowHosts("https://example1.com", "https://example1.com");

            //Assert
            string result = builder.Build();
            Assert.Equal("https://example1.com", result);
        }
    }
}
