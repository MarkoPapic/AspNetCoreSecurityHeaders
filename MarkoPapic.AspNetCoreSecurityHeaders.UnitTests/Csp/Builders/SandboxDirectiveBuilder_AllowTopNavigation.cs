using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowTopNavigation
    {
        [Fact]
        public void NothingElseCalled_TopNavigationReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowTopNavigation();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-top-navigation", result);
        }

        [Fact]
        public void SomethingElseCalled_TopNavigationIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowTopNavigation();
            builder.AllowPopups();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-modals allow-popups allow-top-navigation", result);
        }

        [Fact]
        public void DuplicateTopNavigationAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowTopNavigation().AllowTopNavigation();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-top-navigation", result);
        }
    }
}
