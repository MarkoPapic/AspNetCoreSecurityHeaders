using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowPopups
    {
        [Fact]
        public void NothingElseCalled_PopupsReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowPopups();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-popups", result);
        }

        [Fact]
        public void SomethingElseCalled_PopupsIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowPopups();
            builder.AllowForms();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-forms allow-modals allow-popups", result);
        }

        [Fact]
        public void DuplicatePopupsAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowPopups().AllowPopups();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-popups", result);
        }
    }
}
