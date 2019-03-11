using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class CspOptionsBuilder_BlockAllMixedContent
    {
        [Fact]
        public void Invoked_StringAdded()
        {
            //Arrange
            CspOptionsBuilder builder = new CspOptionsBuilder();

            //Act
            builder.BlockAllMixedContent();

            //Assert
            CspOptions options = builder.Build();
            Assert.Equal("block-all-mixed-content", options.Content);
        }
    }
}
