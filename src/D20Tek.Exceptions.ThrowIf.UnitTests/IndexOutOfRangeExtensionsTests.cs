using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class IndexOutOfRangeExtensionsTests
{
    [TestMethod]
    public void ThrowIf_WithValidIndex_DoesNotThrowException()
    {
        // arrange
        int[] list = [1, 2, 3];

        // assert
        IndexOutOfRangeException.ThrowIf(list, 2);
    }

    [TestMethod]
    public void ThrowIf_WithNegativeIndex_ThrowsException()
    {
        // arrange
        int[] list = [];

        // assert
        var ex = Assert.ThrowsExactly<IndexOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            IndexOutOfRangeException.ThrowIf(list, -1));
    }

    [TestMethod]
    public void ThrowIf_WithHigherIndex_ThrowsException()
    {
        // arrange
        int[] list = [1, 2, 3];

        // assert
        var ex = Assert.ThrowsExactly<IndexOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            IndexOutOfRangeException.ThrowIf(list, 8));
    }

    [TestMethod]
    public void ThrowIf_WithIndexZeroAndEmptyList_ThrowsException()
    {
        // arrange
        int[] list = [];

        // assert
        var ex = Assert.ThrowsExactly<IndexOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            IndexOutOfRangeException.ThrowIf(list, 0));
    }

    [TestMethod]
    public void ThrowIf_Null_ThrowsArgumentNullException()
    {
        // arrange
        int[]? list = null;

        // assert
        var ex = Assert.ThrowsExactly<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            IndexOutOfRangeException.ThrowIf(list, 0));
    }
}
