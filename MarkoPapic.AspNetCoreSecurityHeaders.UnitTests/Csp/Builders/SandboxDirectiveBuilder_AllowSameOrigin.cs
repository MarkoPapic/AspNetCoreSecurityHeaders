using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowSameOrigin
    {
        [Fact]
        public void NothingElseCalled_SameOriginReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowSameOrigin();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-same-origin", result);
        }

        [Fact]
        public void SomethingElseCalled_SameOriginIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowSameOrigin();
            builder.AllowPopups();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-modals allow-popups allow-same-origin", result);
        }

        [Fact]
        public void DuplicateSameOriginAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowSameOrigin().AllowSameOrigin();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-same-origin", result);
        }
    }
}
