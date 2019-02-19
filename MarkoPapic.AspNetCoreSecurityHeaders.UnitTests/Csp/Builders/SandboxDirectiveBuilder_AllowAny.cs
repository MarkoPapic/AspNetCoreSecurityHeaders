using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowAny
    {
        [Fact]
        public void NothingElseCalled_AsteriskReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'*'", result);
        }

        [Fact]
        public void SomethingElseAllowed_OtherssIgnored()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowForms();
            builder.AllowModals();
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'*'", result);
        }

        [Fact]
        public void DuplicateAnyAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowAny().AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal("'*'", result);
        }
    }
}
