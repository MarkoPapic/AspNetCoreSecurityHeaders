using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowScripts
    {
        [Fact]
        public void NothingElseCalled_ScriptsReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowScripts();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-scripts", result);
        }

        [Fact]
        public void SomethingElseCalled_ScriptsIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowScripts();
            builder.AllowPopups();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-modals allow-popups allow-scripts", result);
        }

        [Fact]
        public void DuplicateScriptsAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowScripts().AllowScripts();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-scripts", result);
        }
    }
}
