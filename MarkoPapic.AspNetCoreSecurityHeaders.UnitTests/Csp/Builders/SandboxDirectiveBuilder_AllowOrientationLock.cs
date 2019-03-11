using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowOrientationLock
    {
        [Fact]
        public void NothingElseCalled_OrientationLockReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowOrientationLock();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-orientation-lock", result);
        }

        [Fact]
        public void SomethingElseCalled_OrientationLockIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowOrientationLock();
            builder.AllowForms();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-forms allow-modals allow-orientation-lock", result);
        }

        [Fact]
        public void DuplicateOrientationLockAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowOrientationLock().AllowOrientationLock();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-orientation-lock", result);
        }
    }
}
