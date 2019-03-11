using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class CspOptionsBuilder_UpgradeInsecureRequests
    {
        [Fact]
        public void Invoked_StringAdded()
        {
            //Arrange
            CspOptionsBuilder builder = new CspOptionsBuilder();

            //Act
            builder.UpgradeInsecureRequests();

            //Assert
            CspOptions options = builder.Build();
            Assert.Equal("upgrade-insecure-requests", options.Content);
        }
    }
}
