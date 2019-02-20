using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class FetchDirectivesBuilder_AllowHash
    {
        [Fact]
        public void NothingElseCalled_HashReturned1()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            string inputValue = "sha256-somehash";

            //Act
            builder.AllowHash(inputValue);

            //Assert
            string result = builder.Build();
            Assert.Equal(inputValue, result);
        }

        [Fact]
        public void NothingElseCalled_HashReturned2()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            string inputAlg = "sha256";
            string inputHash = "somehash";

            //Act
            builder.AllowHash(inputAlg, inputHash);

            //Assert
            string result = builder.Build();
            Assert.Equal($"{inputAlg}-{inputHash}", result);
        }

        [Fact]
        public void SomethingElseCalled_HashAdded1()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            string inputValue = "sha256-somehash";

            //Act
            builder.AllowAny();
            builder.AllowHash(inputValue);

            //Assert
            string result = builder.Build();
            Assert.Equal($"{inputValue} *", result);
        }

        [Fact]
        public void SomethingElseCalled_HashAdded2()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            string inputAlg = "sha256";
            string inputHash = "somehash";

            //Act
            builder.AllowAny();
            builder.AllowHash(inputAlg, inputHash);

            //Assert
            string result = builder.Build();
            Assert.Equal($"{inputAlg}-{inputHash} *", result);
        }

        [Fact]
        public void DuplicateHashesAllowed_DuplicatesRemoved1()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            string inputValue = "sha256-somehash";

            //Act
            builder.AllowHash(inputValue).AllowHash(inputValue);

            //Assert
            string result = builder.Build();
            Assert.Equal(inputValue, result);
        }

        [Fact]
        public void DuplicateHashesAllowed_DuplicatesRemoved2()
        {
            //Arrange
            FetchDirectiveBuilder builder = new FetchDirectiveBuilder();
            string inputAlg = "sha256";
            string inputHash = "somehash";

            //Act
            builder.AllowHash(inputAlg, inputHash).AllowHash(inputAlg, inputHash);

            //Assert
            string result = builder.Build();
            Assert.Equal($"{inputAlg}-{inputHash}", result);
        }
    }
}
