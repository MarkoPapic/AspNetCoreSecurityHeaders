using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowNone
    {
        [Fact]
        public void NothingElseCalled_NoneReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowNone();

            //Assert
            string result = builder.Build();
            Assert.Equal("'none'", result);
        }

        [Fact]
        public void SomethingElseCalled_OnlyNoneReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowForms();
            builder.AllowModals();
            builder.AllowNone();
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'none'", result);
        }

        [Fact]
        public void DuplicateNoneAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowNone().AllowNone();

            //Assert
            string result = builder.Build();
            Assert.Equal("'none'", result);
        }
    }
}
