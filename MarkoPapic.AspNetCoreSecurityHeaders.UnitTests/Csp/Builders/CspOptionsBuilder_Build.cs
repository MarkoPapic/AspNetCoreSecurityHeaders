using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class CspOptionsBuilder_Build
    {
        [Fact]
        public void SomeBuildersReturnedDirectives_AllDirectivesIncluded()
        {
            //Arrange
            CspOptionsBuilder builder = new CspOptionsBuilder();

            //Act
            builder.ConnectSources.AllowSelf();
            builder.ScriptSources.AllowHosts("https://example.com");
            builder.Sandbox.AllowModals();

            //Assert
            CspOptions result = builder.Build();
            Assert.Equal("connect-src 'self'; script-src https://example.com; sandbox allow-modals", result.Content);
        }

        [Fact]
        public void SomeBuildersReturnedNulls_NullsNotIncluded()
        {
            //Arrange
            CspOptionsBuilder builder = new CspOptionsBuilder();

            //Act
            builder.ConnectSources.AllowSelf();
            builder.ScriptSources.AllowHosts("https://example.com");
            builder.Sandbox.AllowModals();

            //Assert
            CspOptions result = builder.Build();
            Assert.Equal("connect-src 'self'; script-src https://example.com; sandbox allow-modals", result.Content);
        }

        [Fact]
        public void SomeBuildersReturnedEmptyStrings_EmptyStringsNotIncluded()
        {
            //Arrange
            CspOptionsBuilder builder = new CspOptionsBuilder();

            //Act
            builder.ConnectSources.AllowSelf();
            builder.ScriptSources.AllowHosts("https://example.com");
            builder.Sandbox.AllowModals();

            //Assert
            CspOptions result = builder.Build();
            Assert.Equal("connect-src 'self'; script-src https://example.com; sandbox allow-modals", result.Content);
        }

        [Fact]
        public void MultipeDirectivesReturned_SeparatedByComma()
        {
            //Arrange
            CspOptionsBuilder builder = new CspOptionsBuilder();

            //Act
            builder.ConnectSources.AllowSelf();
            builder.ScriptSources.AllowHosts("https://example.com");
            builder.Sandbox.AllowModals();

            //Assert
            CspOptions result = builder.Build();
            Assert.Equal("connect-src 'self'; script-src https://example.com; sandbox allow-modals", result.Content);
        }
    }
}
