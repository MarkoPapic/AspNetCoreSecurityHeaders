using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class RequireSriForDirective_ScriptStyle
    {
        [Fact]
        public void NothingElseCalled_ScriptStyleReturned()
        {
            //Arrange
            RequireSriForDirectiveBuilder builder = new RequireSriForDirectiveBuilder();

            //Act
            builder.ScriptStyle();

            //Assert
            string result = builder.Build();
            Assert.Equal("script style", result);
        }

        [Fact]
        public void SomethingElseCalled_PreviousOverwritten()
        {
            //Arrange
            RequireSriForDirectiveBuilder builder = new RequireSriForDirectiveBuilder();

            //Act
            builder.Script();
            builder.ScriptStyle();

            //Assert
            string result = builder.Build();
            Assert.Equal("script style", result);
        }
    }
}
