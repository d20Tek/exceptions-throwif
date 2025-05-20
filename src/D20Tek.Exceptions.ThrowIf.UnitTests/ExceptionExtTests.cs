using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class ExceptionExtTests
{
    [TestMethod]
    public void ThrowIf_DoesNotThrow_WhenConditionIsFalse()
    {
        // arrange

        // act
        ExceptionExt.ThrowIf<InvalidOperationException>(false, "This should not be thrown");

        // assert
    }

    [TestMethod]
    public void ThrowIf_ThrowsArgumentException_WhenConditionIsTrue()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsException<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ExceptionExt.ThrowIf<ArgumentException>(true, "Invalid argument provided"));
    }

    [TestMethod]
    public void ThrowIf_ThrowsInvalidOperationException_WhenConditionIsTrue()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsException<InvalidOperationException>([ExcludeFromCodeCoverage] () =>
            ExceptionExt.ThrowIf<InvalidOperationException>(true, "Invalid operation"));
    }

    [TestMethod]
    public void ThrowIf_ThrowsMissingMethodException_WhenExceptionTypeHasNoStringConstructor()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsException<MissingMethodException>([ExcludeFromCodeCoverage] () =>
            ExceptionExt.ThrowIf<ExceptionWithoutStringConstructor>(true, "No message constructor"));
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

        // act
        ExceptionExt.ThrowIfNot<InvalidOperationException>(true, "This should not be thrown");

        // assert
    }

    [TestMethod]
    public void ThrowIfNot_ThrowsArgumentException_WhenConditionIsFalse()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsException<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ExceptionExt.ThrowIfNot<ArgumentException>(false, "Invalid argument provided"));
    }

    [TestMethod]
    public void ThrowIf_DoesNotThrow_WhenFuncConditionIsFalse()
    {
        // arrange

        // act
        ExceptionExt.ThrowIf<InvalidOperationException>(() => false, "This should not be thrown");

        // assert
    }

    [TestMethod]
    public void ThrowIf_ThrowsArgumentException_WhenFuncConditionIsTrue()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsException<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ExceptionExt.ThrowIf<ArgumentException>(() => true, "Invalid argument provided"));
    }

    [TestMethod]
    public void ThrowIfNot_DoesNotThrow_WhenFuncConditionIsTrue()
    {
        // arrange

        // act
        ExceptionExt.ThrowIfNot<InvalidOperationException>(() => true, "This should not be thrown");

        // assert
    }

    [TestMethod]
    public void ThrowIfNot_ThrowsArgumentException_WhenFuncConditionIsFalse()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsException<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ExceptionExt.ThrowIfNot<ArgumentException>(() => false, "Invalid argument provided"));
    }

    public class MyCustomException : Exception
    {
        public MyCustomException(string message)
            :base(message) { }
    }

    [TestMethod]
    public void ThrowIf_WithCustomException()
    {
        int v = 12;
        ExceptionExt.ThrowIf<MyCustomException>(() => v < 0, "Invalid value, use custom exception");

        var ex = Assert.ThrowsException<MyCustomException>([ExcludeFromCodeCoverage] () =>
            ExceptionExt.ThrowIf<MyCustomException>(() => v >= 10, "Invalid value, use custom exception - this one throws"));
    }

}
