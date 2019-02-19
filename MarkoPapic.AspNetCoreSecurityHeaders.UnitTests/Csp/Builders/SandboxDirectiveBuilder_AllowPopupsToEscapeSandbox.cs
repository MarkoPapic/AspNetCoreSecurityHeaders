using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowPopupsToEscapeSandbox
    {
        [Fact]
        public void NothingElseCalled_PopupsToEscapeSandboxReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowPopupsToEscapeSandbox();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-popups-to-escape-sandbox", result);
        }

        [Fact]
        public void SomethingElseCalled_PopupsToEscapeSandboxIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowPopupsToEscapeSandbox();
            builder.AllowForms();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-forms allow-modals allow-popups-to-escape-sandbox", result);
        }

        [Fact]
        public void PopupsToEscapeSandboxAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowPopupsToEscapeSandbox().AllowPopupsToEscapeSandbox();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-popups-to-escape-sandbox", result);
        }
    }
}
