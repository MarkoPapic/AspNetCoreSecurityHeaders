using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowModals
    {
        [Fact]
        public void NothingElseCalled_ModalsReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-modals", result);
        }

        [Fact]
        public void SomethingElseCalled_ModalsIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowForms();
            builder.AllowModals();
            builder.AllowPopups();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-forms allow-modals allow-popups", result);
        }

        [Fact]
        public void DuplicateModalsAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals().AllowModals();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-modals", result);
        }
    }
}
