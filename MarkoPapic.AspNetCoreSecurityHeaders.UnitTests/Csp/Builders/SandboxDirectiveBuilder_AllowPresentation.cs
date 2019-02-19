using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowPresentation
    {
        [Fact]
        public void NothingElseCalled_PresentationReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowPresentation();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-presentation", result);
        }

        [Fact]
        public void SomethingElseCalled_PresentationIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowPresentation();
            builder.AllowPopups();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-modals allow-popups allow-presentation", result);
        }

        [Fact]
        public void DuplicatePresentationAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowPresentation().AllowPresentation();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-presentation", result);
        }
    }
}
