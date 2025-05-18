using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class ArgumentNullExtTests
{
    [TestMethod]
    public void ThrowIfNullOrEmpty_WithFullArray_DoesNotThrowException()
    {
        // arrange
        var list = new int[] { 3, 7, 5, 9 };

        // act
        ArgumentNullExceptionExt.ThrowIfNullOrEmpty(list);

        // assert
    }

    [TestMethod]
    public void ThrowIfNullOrEmpty_WithEmptyArray_ThrowsException()
    {
        // arrange
        int[] list = [];

        // assert
        var ex = Assert.ThrowsException<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrEmpty(list));

        Assert.AreEqual(nameof(list), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNullOrEmpty_WithNullList_ThrowsException()
    {
        // arrange
        List<string>? list = null;

        // assert
        var ex = Assert.ThrowsException<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrEmpty(list));

        Assert.AreEqual(nameof(list), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNullOrEmpty_WithFullDictionary_DoesNotThrowException()
    {
        // arrange
        var dict = new Dictionary<int, string>
        {
            { 3, "Three" },
            { 7, "Seven" },
            { 5, "Five" }
        };

        // act
        ArgumentNullExceptionExt.ThrowIfNullOrEmpty(dict);

        // assert
    }

    [TestMethod]
    public void ThrowIfNullOrEmpty_WithEmptyDictionary_ThrowsException()
    {
        // arrange
        var dict = new Dictionary<int, string>();

        // assert
        var ex = Assert.ThrowsException<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrEmpty(dict));

        Assert.AreEqual(nameof(dict), ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNullOrEmpty_WithNullDictionary_ThrowsException()
    {
        // arrange
        IDictionary<int, string>? dict = null;

        // assert
        var ex = Assert.ThrowsException<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            ArgumentNullExceptionExt.ThrowIfNullOrEmpty(dict!));

        Assert.AreEqual(nameof(dict), ex.ParamName);
    }
}
