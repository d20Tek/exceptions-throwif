using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class ExceptionExtTests
{
    [TestMethod]
    public void ThrowIf_DoesNotThrow_WhenConditionIsFalse()
    {
        // arrange

        // act - assert
        Exception.ThrowIf<InvalidOperationException>(false, "This should not be thrown");
    }

    [TestMethod]
    public void ThrowIf_ThrowsArgumentException_WhenConditionIsTrue()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            Exception.ThrowIf<ArgumentException>(true, "Invalid argument provided"));
    }

    [TestMethod]
    public void ThrowIf_ThrowsInvalidOperationException_WhenConditionIsTrue()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsExactly<InvalidOperationException>([ExcludeFromCodeCoverage] () =>
            Exception.ThrowIf<InvalidOperationException>(true, "Invalid operation"));
    }

    [TestMethod]
    public void ThrowIf_ThrowsMissingMethodException_WhenExceptionTypeHasNoStringConstructor()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsExactly<MissingMethodException>([ExcludeFromCodeCoverage] () =>
            Exception.ThrowIf<ExceptionWithoutStringConstructor>(true, "No message constructor"));
    }

    // Helper class for testing fallback failure behavior
    [ExcludeFromCodeCoverage]
    private class ExceptionWithoutStringConstructor : Exception
    {
        public ExceptionWithoutStringConstructor() { }
    }

    [TestMethod]
    public void ThrowIfNot_DoesNotThrow_WhenConditionIsTrue()
    {
        // arrange

        // act - assert
        Exception.ThrowIfNot<InvalidOperationException>(true, "This should not be thrown");
    }

    [TestMethod]
    public void ThrowIfNot_ThrowsArgumentException_WhenConditionIsFalse()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            Exception.ThrowIfNot<ArgumentException>(false, "Invalid argument provided"));
    }

    [TestMethod]
    public void ThrowIf_DoesNotThrow_WhenFuncConditionIsFalse()
    {
        // arrange

        // act - assert
        Exception.ThrowIf<InvalidOperationException>(() => false, "This should not be thrown");
    }

    [TestMethod]
    public void ThrowIf_ThrowsArgumentException_WhenFuncConditionIsTrue()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            Exception.ThrowIf<ArgumentException>(() => true, "Invalid argument provided"));
    }

    [TestMethod]
    public void ThrowIfNot_DoesNotThrow_WhenFuncConditionIsTrue()
    {
        // arrange

        // act - assert
        Exception.ThrowIfNot<InvalidOperationException>(() => true, "This should not be thrown");
    }

    [TestMethod]
    public void ThrowIfNot_ThrowsArgumentException_WhenFuncConditionIsFalse()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            Exception.ThrowIfNot<ArgumentException>(() => false, "Invalid argument provided"));
    }

    public class MyCustomException(string message) : Exception(message)
    {
    }

    [TestMethod]
    public void ThrowIf_WithCustomException()
    {
        // arrange
        int v = 12;
        Exception.ThrowIf<MyCustomException>(() => v < 0, "Invalid value, use custom exception");

        // act - assert
        var ex = Assert.ThrowsExactly<MyCustomException>([ExcludeFromCodeCoverage] () =>
            Exception.ThrowIf<MyCustomException>(() => v >= 10, "Invalid value, use custom exception - this one throws"));
    }

}
