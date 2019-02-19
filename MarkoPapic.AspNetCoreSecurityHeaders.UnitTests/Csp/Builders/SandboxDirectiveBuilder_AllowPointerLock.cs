using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowPointerLock
    {
        [Fact]
        public void NothingElseCalled_PointerLockReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowPointerLock();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-pointer-lock", result);
        }

        [Fact]
        public void SomethingElseCalled_PointerLockIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowPointerLock();
            builder.AllowForms();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-forms allow-modals allow-pointer-lock", result);
        }

        [Fact]
        public void DuplicatePointerLockAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowPointerLock().AllowPointerLock();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-pointer-lock", result);
        }
    }
}
