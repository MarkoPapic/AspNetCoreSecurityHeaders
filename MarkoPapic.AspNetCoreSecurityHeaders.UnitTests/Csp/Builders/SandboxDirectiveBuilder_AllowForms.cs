using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class SandboxDirectiveBuilder_AllowForms
    {
        [Fact]
        public void NothingElseCalled_FormsReturned()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowForms();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-forms", result);
        }

        [Fact]
        public void SomethingElseCalled_FormsIncluded()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowModals();
            builder.AllowForms();
            builder.AllowPopups();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-forms allow-modals allow-popups", result);
        }

        [Fact]
        public void DuplicateFormsAllowed_DuplicatesRemoved()
        {
            //Arrange
            SandboxDirectiveBuilder builder = new SandboxDirectiveBuilder();

            //Act
            builder.AllowForms().AllowForms();

            //Assert
            string result = builder.Build();
            Assert.Equal("allow-forms", result);
        }
    }
}
