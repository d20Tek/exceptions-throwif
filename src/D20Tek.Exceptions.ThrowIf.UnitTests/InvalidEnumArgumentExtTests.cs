using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class InvalidEnumArgumentExtTests
{
    public enum TestType
    {
        None,
        Some,
        Examples
    };

    [TestMethod]
    public void ThrowIfInvalidEnum_WithValidEnumValue_DoesNotThrowException()
    {
        // arrange
        var test = TestType.Some;

        // act
        InvalidEnumArgumentExceptionExt.ThrowIfInvalidEnum(test);

        // assert
    }

    [TestMethod]
    public void ThrowIfInvalidEnum_WithInvalidEnumValue_ThrowsException()
    {
        // arrange
        var test = (TestType)99;

        // assert
        Assert.ThrowsException<InvalidEnumArgumentException>([ExcludeFromCodeCoverage] () =>
            InvalidEnumArgumentExceptionExt.ThrowIfInvalidEnum(test));
    }
}
