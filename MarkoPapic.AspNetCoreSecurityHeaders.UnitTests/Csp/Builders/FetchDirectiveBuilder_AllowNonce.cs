using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Contracts;
using Moq;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class FetchDirectiveBuilder_AllowNonce
    {
        [Fact]
        public void NothingElseCalled_NonceReturned()
        {
            //Arrange
            string generatedNonce = "somenonce";
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            Mock<ICspNonceService> nonceServiceMock = new Mock<ICspNonceService>();
            nonceServiceMock.Setup(x => x.GetNonce()).Returns(generatedNonce);

            //Act
            builder.AllowNonce(nonceServiceMock.Object);

            //Assert
            string result = builder.Build();
            Assert.Equal($"'nonce-{generatedNonce}'", result);
        }

        [Fact]
        public void SomethingElseCalled_NonceAdded()
        {
            //Arrange
            string generatedNonce = "somenonce";
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            Mock<ICspNonceService> nonceServiceMock = new Mock<ICspNonceService>();
            nonceServiceMock.Setup(x => x.GetNonce()).Returns(generatedNonce);

            //Act
            builder.AllowNonce(nonceServiceMock.Object);
            builder.AllowAny();

            //Assert
            string result = builder.Build();
            Assert.Equal($"'nonce-{generatedNonce}' '*'", result);
        }

        [Fact]
        public void DuplicateNonceAllowed_DuplicatesRemoved()
        {
            //Arrange
            string generatedNonce = "somenonce";
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            Mock<ICspNonceService> nonceServiceMock = new Mock<ICspNonceService>();
            nonceServiceMock.Setup(x => x.GetNonce()).Returns(generatedNonce);

            //Act
            builder.AllowNonce(nonceServiceMock.Object).AllowNonce(nonceServiceMock.Object);

            //Assert
            string result = builder.Build();
            Assert.Equal($"'nonce-{generatedNonce}'", result);
        }
    }
}
