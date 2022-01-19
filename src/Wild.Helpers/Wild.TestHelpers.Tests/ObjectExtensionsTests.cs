using FluentAssertions;
using Wild.TestHelpers.Extensions;
using Xunit;

namespace Wild.TestHelpers.Tests;

public class ObjectExtensionsTests
{
    [Fact]
    public void ObjectExtensions_ToExpandoObject_Returns_Expected_Value()
    {
        object obj = new
        {
            x = 1,
            s = "Hello World"
        };

        dynamic result = obj.ToExpandoObject();

        var xInt = (int)result.x;
        xInt.Should().Be(1);

        var str = (string)result.s;
        str.Should().Be("Hello World");
    }
}