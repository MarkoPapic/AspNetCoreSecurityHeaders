using System;
using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Csp.Builders
{
    public class FrameAncestorsDirectiveBuilder_AllowSchemas
    {
        [Fact]
        public void NothingElseCalled_SchemasReturned()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowSchemas("blob:");

            //Assert
            string result = builder.Build();
            Assert.Equal("blob:", result);
        }

        [Fact]
        public void SomethingElseCalled_SchemasIncluded()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowSelf();
            builder.AllowSchemas("blob:");

            //Assert
            string result = builder.Build();
            Assert.Equal("'self' blob:", result);
        }

        [Fact]
        public void DuplicateSchemasAllowed_DuplicatesRemoved()
        {
            //Arrange
            FrameAncestorsDirectiveBuilder builder = new FrameAncestorsDirectiveBuilder();

            //Act
            builder.AllowSchemas("blob:", "blob:");

            //Assert
            string result = builder.Build();
            Assert.Equal("blob:", result);
        }
    }
}
