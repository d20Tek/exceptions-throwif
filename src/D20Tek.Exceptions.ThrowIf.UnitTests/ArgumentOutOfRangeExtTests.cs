using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public sealed class ArgumentOutOfRangeExtTests
{
    [TestMethod]
    [DataRow(5, 1, 10)]
    [DataRow(1, 1, 10)]
    [DataRow(10, 1, 10)]
    [DataRow(5, 5, 5)]
    public void ThrowIfOutOfRange_DoesNotThrowException(int check, int min, int max)
    {
        // arrange

        // act - assert
        ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, min, max);
    }

    [TestMethod]
    [DataRow(15, 1, 10)]
    [DataRow(1, 10, 20)]
    [DataRow(5, 10, 1)]
    public void ThrowIfOutOfRange_ThrowsException(int check, int min, int max)
    {
        // arrange

        // assert
        var ex = Assert.ThrowsExactly<ArgumentOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, min, max));

        Assert.AreEqual(nameof(check), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfOutOfRangeFloat_WithMaxValue_DoesNotThrowException()
    {
        // arrange
        var check = 3.14f;

        // act - assert
        ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, 1.0f, 10.0f);
    }

    [TestMethod]
    public void ThrowIfOutOfRangeFloat_WithGreaterThanMax_ThrowException()
    {
        // arrange
        var check = 10.35f;

        // act - assert
        Assert.ThrowsExactly<ArgumentOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, 1.0f, 10.0f));
    }

    [TestMethod]
    public void ThrowIfOutOfRangeExclusive_WithValueInRange_DoesNotThrowException()
    {
        // arrange
        var check = 5;

        // act - assert
        ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRangeExclusive(check, 1, 10);
    }

    [TestMethod]
    [DataRow(1, 1, 10)]
    [DataRow(10, 1, 10)]
    [DataRow(15, 1, 10)]
    [DataRow(1, 10, 20)]
    [DataRow(5, 5, 5)]
    [DataRow(5, 10, 1)]
    public void ThrowIfOutOfRangeExclusive_ThrowsException(int check, int min, int max)
    {
        // arrange

        // act - assert
        var ex = Assert.ThrowsExactly<ArgumentOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRangeExclusive(check, min, max));

        Assert.AreEqual(nameof(check), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfOutOfRangeDecimal_WithMaxValue_DoesNotThrowException()
    {
        // arrange
        var check = 3.14M;

        // act - assert
        ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRangeExclusive(check, 1.0M, 10.0M);
    }

    [TestMethod]
    public void ThrowIfOutOfRangeDecimal_WithGreaterThanMax_DoesNotThrow()
    {
        // arrange
        var check = 10.35m;

        // act - assert
        Assert.ThrowsExactly<ArgumentOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, 1.0m, 10.0m));
    }
}
