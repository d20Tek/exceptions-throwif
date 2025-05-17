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

        // act
        ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, min, max);

        // assert
    }

    [TestMethod]
    [DataRow(15, 1, 10)]
    [DataRow(1, 10, 20)]
    [DataRow(5, 10, 1)]
    public void ThrowIfOutOfRange_ThrowsException(int check, int min, int max)
    {
        // arrange

        // assert
        var ex = Assert.ThrowsException<ArgumentOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, min, max));

        Assert.AreEqual(nameof(check), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfOutOfRangeFloat_WithMaxValue_DoesNotThrowException()
    {
        // arrange
        var check = 3.14f;

        // act
        ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, 1.0f, 10.0f);

        // assert
    }

    [TestMethod]
    public void ThrowIfOutOfRangeFloat_WithGreaterThanMax_ThrowException()
    {
        // arrange
        var check = 10.35f;

        // act
        Assert.ThrowsException<ArgumentOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, 1.0f, 10.0f));
    }

    [TestMethod]
    public void ThrowIfOutOfRangeExclusive_WithValueInRange_DoesNotThrowException()
    {
        // arrange
        var check = 5;

        // act
        ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRangeExclusive(check, 1, 10);

        // assert
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

        // assert
        var ex = Assert.ThrowsException<ArgumentOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRangeExclusive(check, min, max));

        Assert.AreEqual(nameof(check), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfOutOfRangeDecimal_WithMaxValue_DoesNotThrowException()
    {
        // arrange
        var check = 3.14M;

        // act
        ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRangeExclusive(check, 1.0M, 10.0M);

        // assert
    }

    [TestMethod]
    public void ThrowIfOutOfRangeDecimal_WithGreaterThanMax_DoesNotThrow()
    {
        // arrange
        var check = 10.35m;

        // act
        Assert.ThrowsException<ArgumentOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(check, 1.0m, 10.0m));
    }
}
