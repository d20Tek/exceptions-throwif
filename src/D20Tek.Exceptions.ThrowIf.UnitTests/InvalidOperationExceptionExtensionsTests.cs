using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class InvalidOperationExceptionExtensionsTests
{
    [TestMethod]
    public void ThrowIf_WithFalseCondition_DoesNotThrow()
    {
        // arrange
        bool condition = false;
        string message = "This should not be thrown";

        // act - assert
        InvalidOperationException.ThrowIf(condition, message);
    }

    [TestMethod]
    public void ThrowIf_WithTrueCondition_ThrowsInvalidOperationException()
    {
        // arrange
        bool condition = true;
        string message = "Invalid operation occurred";

        // act
        var ex = Assert.ThrowsExactly<InvalidOperationException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIf(condition, message));

        // assert
        Assert.AreEqual("Invalid operation occurred", ex.Message);
    }

    [TestMethod]
    public void ThrowIf_WithFuncReturningFalse_DoesNotThrow()
    {
        // arrange
        static bool condition() => false;
        string message = "This should not be thrown";

        // act - assert
        InvalidOperationException.ThrowIf(condition, message);
    }

    [TestMethod]
    public void ThrowIf_WithFuncReturningTrue_ThrowsInvalidOperationException()
    {
        // arrange
        static bool condition() => true;
        string message = "Invalid operation from func";

        // act
        var ex = Assert.ThrowsExactly<InvalidOperationException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIf(condition, message));

        // assert
        Assert.AreEqual("Invalid operation from func", ex.Message);
    }

    [TestMethod]
    public void ThrowIf_WithComplexCondition_DoesNotThrow()
    {
        // arrange
        int value = 10;
        bool condition() => value < 0 || value > 100;
        string message = "Value out of range";

        // act - assert
        InvalidOperationException.ThrowIf(condition, message);
    }

    [TestMethod]
    public void ThrowIf_WithComplexCondition_ThrowsInvalidOperationException()
    {
        // arrange
        int value = 150;
        bool condition() => value < 0 || value > 100;
        string message = "Value out of range";

        // act
        var ex = Assert.ThrowsExactly<InvalidOperationException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIf(condition, message));

        // assert
        Assert.AreEqual("Value out of range", ex.Message);
    }

    [TestMethod]
    public void ThrowIfDisposed_WithNotDisposed_DoesNotThrow()
    {
        // arrange
        bool isDisposed = false;

        // act - assert
        InvalidOperationException.ThrowIfDisposed(isDisposed);
    }

    [TestMethod]
    public void ThrowIfDisposed_WithDisposed_ThrowsObjectDisposedException()
    {
        // arrange
        bool isDisposed = true;

        // act
        var ex = Assert.ThrowsExactly<ObjectDisposedException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIfDisposed(isDisposed));

        // assert
        Assert.Contains("isDisposed", ex.Message);
        Assert.Contains("disposed", ex.Message);
    }

    [TestMethod]
    public void ThrowIfDisposed_WithDisposedAndCustomObjectName_ThrowsObjectDisposedException()
    {
        // arrange
        bool disposed = true;

        // act
        var ex = Assert.ThrowsExactly<ObjectDisposedException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIfDisposed(disposed, "MyCustomObject"));

        // assert
        Assert.Contains("MyCustomObject", ex.Message);
        Assert.Contains("disposed", ex.Message);
    }

    [TestMethod]
    public void ThrowIfDisposed_WithFuncReturningFalse_DoesNotThrow()
    {
        // arrange
        static bool isDisposed() => false;

        // act - assert
        InvalidOperationException.ThrowIfDisposed(isDisposed);
    }

    [TestMethod]
    public void ThrowIfDisposed_WithFuncReturningTrue_ThrowsObjectDisposedException()
    {
        // arrange
        static bool isDisposed() => true;

        // act
        var ex = Assert.ThrowsExactly<ObjectDisposedException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIfDisposed(isDisposed));

        // assert
        Assert.Contains("isDisposed", ex.Message);
        Assert.Contains("disposed", ex.Message);
    }

    [TestMethod]
    public void ThrowIfDisposed_WithFuncAndCustomObjectName_ThrowsObjectDisposedException()
    {
        // arrange
        bool disposed = true;
        bool isDisposed() => disposed;

        // act
        var ex = Assert.ThrowsExactly<ObjectDisposedException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIfDisposed(isDisposed, "CustomResource"));

        // assert
        Assert.Contains("CustomResource", ex.Message);
        Assert.Contains("disposed", ex.Message);
    }

    [TestMethod]
    public void ThrowIfDisposed_WithRealWorldScenario_WorksCorrectly()
    {
        // arrange
        var resource = new DisposableResource();

        // act - assert (not disposed)
        InvalidOperationException.ThrowIfDisposed(resource.IsDisposed);

        // dispose and verify exception
        resource.Dispose();
        var ex = Assert.ThrowsExactly<ObjectDisposedException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIfDisposed(resource.IsDisposed));

        // assert
        Assert.Contains("disposed", ex.Message);
    }

    [TestMethod]
    public void ThrowIf_WithEmptyMessage_ThrowsWithEmptyMessage()
    {
        // arrange
        bool condition = true;
        string message = "";

        // act
        var ex = Assert.ThrowsExactly<InvalidOperationException>([ExcludeFromCodeCoverage] () =>
            InvalidOperationException.ThrowIf(condition, message));

        // assert
        Assert.AreEqual("", ex.Message);
    }

    // Helper class for testing disposal scenarios
    [ExcludeFromCodeCoverage]
    private class DisposableResource : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}