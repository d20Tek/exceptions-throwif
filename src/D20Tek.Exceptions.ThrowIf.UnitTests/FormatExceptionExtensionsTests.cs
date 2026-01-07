using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class FormatExceptionExtensionsTests
{
    [TestMethod]
    public void ThrowIfInvalidFormat_WithValidInt_DoesNotThrow()
    {
        // arrange
        string value = "123";

        // act
        FormatException.ThrowIfInvalidFormat<int>(value, out var result);

        // assert
        Assert.AreEqual(123, result);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithInvalidInt_ThrowsFormatException()
    {
        // arrange
        string value = "abc";

        // act
        var ex = Assert.ThrowsExactly<FormatException>([ExcludeFromCodeCoverage] () =>
            FormatException.ThrowIfInvalidFormat<int>(value, out var result));

        // assert
        Assert.Contains("value", ex.Message);
        Assert.Contains("Int32", ex.Message);
        Assert.Contains("abc", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithValidDouble_DoesNotThrow()
    {
        // arrange
        string value = "123.456";

        // act
        FormatException.ThrowIfInvalidFormat<double>(value, out var result);

        // assert
        Assert.AreEqual(123.456, result);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithInvalidDouble_ThrowsFormatException()
    {
        // arrange
        string value = "not-a-number";

        // act
        var ex = Assert.ThrowsExactly<FormatException>([ExcludeFromCodeCoverage] () =>
            FormatException.ThrowIfInvalidFormat<double>(value, out var result));

        // assert
        Assert.Contains("value", ex.Message);
        Assert.Contains("Double", ex.Message);
        Assert.Contains("not-a-number", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithValidDateTime_DoesNotThrow()
    {
        // arrange
        string value = "2026-01-06";

        // act
        FormatException.ThrowIfInvalidFormat<DateTime>(value, out var result);

        // assert
        Assert.AreEqual(new DateTime(2026, 1, 6), result);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithInvalidDateTime_ThrowsFormatException()
    {
        // arrange
        string value = "invalid-date";

        // act
        var ex = Assert.ThrowsExactly<FormatException>([ExcludeFromCodeCoverage] () =>
            FormatException.ThrowIfInvalidFormat<DateTime>(value, out var result));

        // assert
        Assert.Contains("value", ex.Message);
        Assert.Contains("DateTime", ex.Message);
        Assert.Contains("invalid-date", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithValidGuid_DoesNotThrow()
    {
        // arrange
        var expectedGuid = Guid.NewGuid();
        string value = expectedGuid.ToString();

        // act
        FormatException.ThrowIfInvalidFormat<Guid>(value, out var result);

        // assert
        Assert.AreEqual(expectedGuid, result);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithInvalidGuid_ThrowsFormatException()
    {
        // arrange
        string value = "not-a-guid";

        // act
        var ex = Assert.ThrowsExactly<FormatException>([ExcludeFromCodeCoverage] () =>
            FormatException.ThrowIfInvalidFormat<Guid>(value, out var result));

        // assert
        Assert.Contains("value", ex.Message);
        Assert.Contains("Guid", ex.Message);
        Assert.Contains("not-a-guid", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithValidBool_DoesNotThrow()
    {
        // arrange
        string value = "true";

        // act
        FormatException.ThrowIfInvalidFormat<bool>(value, out var result);

        // assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithInvalidBool_ThrowsFormatException()
    {
        // arrange
        string value = "yes";

        // act
        var ex = Assert.ThrowsExactly<FormatException>([ExcludeFromCodeCoverage] () =>
            FormatException.ThrowIfInvalidFormat<bool>(value, out var result));

        // assert
        Assert.Contains("value", ex.Message);
        Assert.Contains("Boolean", ex.Message);
        Assert.Contains("yes", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithValidDecimal_DoesNotThrow()
    {
        // arrange
        string value = "123.45";

        // act
        FormatException.ThrowIfInvalidFormat<decimal>(value, out var result);

        // assert
        Assert.AreEqual(123.45m, result);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithInvalidDecimal_ThrowsFormatException()
    {
        // arrange
        string value = "12.34.56";

        // act
        var ex = Assert.ThrowsExactly<FormatException>([ExcludeFromCodeCoverage] () =>
            FormatException.ThrowIfInvalidFormat<decimal>(value, out var result));

        // assert
        Assert.Contains("value", ex.Message);
        Assert.Contains("Decimal", ex.Message);
        Assert.Contains("12.34.56", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithNegativeNumber_DoesNotThrow()
    {
        // arrange
        string value = "-456";

        // act
        FormatException.ThrowIfInvalidFormat<int>(value, out var result);

        // assert
        Assert.AreEqual(-456, result);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithEmptyString_ThrowsFormatException()
    {
        // arrange
        string value = "";

        // act
        var ex = Assert.ThrowsExactly<FormatException>([ExcludeFromCodeCoverage] () =>
            FormatException.ThrowIfInvalidFormat<int>(value, out var result));

        // assert
        Assert.Contains("value", ex.Message);
        Assert.Contains("Int32", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithWhitespace_ThrowsFormatException()
    {
        // arrange
        string value = "   ";

        // act
        var ex = Assert.ThrowsExactly<FormatException>([ExcludeFromCodeCoverage] () =>
            FormatException.ThrowIfInvalidFormat<int>(value, out var result));

        // assert
        Assert.Contains("value", ex.Message);
        Assert.Contains("Int32", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidFormat_WithLeadingAndTrailingWhitespace_DoesNotThrow()
    {
        // arrange
        string value = "  42  ";

        // act
        FormatException.ThrowIfInvalidFormat<int>(value, out var result);

        // assert
        Assert.AreEqual(42, result);
    }
}