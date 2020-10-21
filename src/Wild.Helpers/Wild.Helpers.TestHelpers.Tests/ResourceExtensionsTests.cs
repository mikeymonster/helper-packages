using System;
using FluentAssertions;
using Wild.Helpers.TestHelpers.Extensions;
using Xunit;

namespace Wild.Helpers.TestHelpers.Tests
{
    public class ResourceExtensionsTests
    {
        [Fact]
        public void ResourceExtensions_ReadManifestResourceStreamAsString_Bad_Path_Throws_Exception()
        {
            const string path = "Bad_Path";

            FluentActions.Invoking(() => path.ReadManifestResourceStreamAsString())
                .Should().Throw<Exception>()
                .And.Message.Should().Be($"Stream for '{path}' not found.");
        }

        [Fact]
        public void ResourceExtensions_ReadManifestResourceStreamAsString_Gets_File()
        {
            var result = "Wild.Helpers.TestHelpers.Tests.TestData.TextFile.txt"
                .ReadManifestResourceStreamAsString();

            result.Should().NotBeNull();
            result.Should().Be("This is a test");
        }
    }
}
