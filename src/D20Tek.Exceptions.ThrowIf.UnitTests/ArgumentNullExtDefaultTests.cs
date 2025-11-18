using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class ArgumentNullExtDefaultTests
{
    [TestMethod]
    public void ThrowIfNullOrDefault_StringIsNotNullOrEmpty_DoesNotThrow()
    {
        // arrange

        // act - assert
        ArgumentNullExceptionExt.ThrowIfNullOrDefault("valid string", "paramName");
    }

    [TestMethod]
    public void ThrowIfNullOrDefault_StringIsNull_ThrowsArgumentException()
    {
        // arrange
        string? test = null;

        // assert
        var ex = Assert.ThrowsExactly<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrDefault(test));

        Assert.AreEqual(nameof(test), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNullOrDefault_IntIsNonZero_DoesNotThrow()
    {
        // arrange

        // act - assert
        ArgumentNullExceptionExt.ThrowIfNullOrDefault(123, "number");
    }

    [TestMethod]
    public void ThrowIfNullOrDefault_IntIsZero_ThrowsArgumentException()
    {
        // arrange
        int number = 0;

        // assert
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrDefault(number));

        Assert.AreEqual(nameof(number), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNullOrDefault_DateTimeIsMinValue_ThrowsArgumentException()
    {
        // arrange
        var date = DateTime.MinValue;

        // assert
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrDefault(date));

        Assert.AreEqual(nameof(date), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNullOrDefault_DateTimeIsValid_DoesNotThrow()
    {
        // arrange
        var date = DateTime.Now;

        // act - assert
        ArgumentNullExceptionExt.ThrowIfNullOrDefault(date);
    }

    [TestMethod]
    public void ThrowIfNullOrDefault_GuidIsEmpty_ThrowsArgumentException()
    {
        // arrange
        var id = default(Guid);

        // assert
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrDefault(id));

        Assert.AreEqual(nameof(id), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNullOrDefault_GuidIsNonEmpty_DoesNotThrow()
    {
        // arrange
        var id = Guid.NewGuid();

        // act - assert
        ArgumentNullExceptionExt.ThrowIfNullOrDefault(id);
    }

    [TestMethod]
    public void ThrowIfNullOrDefault_CustomTypeWithDefaultValue_Throws()
    {
        // arrange
        var value = default(MyStruct);

        // assert
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrDefault(value));

        Assert.AreEqual(nameof(value), ex.ParamName);
    }

    [ExcludeFromCodeCoverage]
    private struct MyStruct
    {
        public int Value { get; set; }
    }
}
