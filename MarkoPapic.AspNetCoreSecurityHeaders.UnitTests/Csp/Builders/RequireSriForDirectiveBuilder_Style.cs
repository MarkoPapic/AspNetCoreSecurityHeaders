using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class RequireSriForDirectiveBuilder_Style
    {
        [Fact]
        public void NothingElseCalled_StyleReturned()
        {
            //Arrange
            RequireSriForDirectiveBuilder builder = new RequireSriForDirectiveBuilder();

            //Act
            builder.Style();

            //Assert
            string result = builder.Build();
            Assert.Equal("style", result);
        }

        [Fact]
        public void SomethingElseCalled_PreviousOverwritten()
        {
            //Arrange
            RequireSriForDirectiveBuilder builder = new RequireSriForDirectiveBuilder();

            //Act
            builder.Script();
            builder.Style();

            //Assert
            string result = builder.Build();
            Assert.Equal("style", result);
        }
    }
}
