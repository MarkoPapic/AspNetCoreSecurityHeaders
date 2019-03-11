using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class RequireSriForDirectiveBuilder_Script
    {
        [Fact]
        public void NothingElseCalled_ScriptReturned()
        {
            //Arrange
            RequireSriForDirectiveBuilder builder = new RequireSriForDirectiveBuilder();

            //Act
            builder.Script();

            //Assert
            string result = builder.Build();
            Assert.Equal("script", result);
        }

        [Fact]
        public void SomethingElseCalled_PreviousOverwritten()
        {
            //Arrange
            RequireSriForDirectiveBuilder builder = new RequireSriForDirectiveBuilder();

            //Act
            builder.Style();
            builder.Script();

            //Assert
            string result = builder.Build();
            Assert.Equal("script", result);
        }
    }
}
