using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class IndexOutOfRangeExtTests
{
    [TestMethod]
    public void ThrowIf_WithValidIndex_DoesNotThrowException()
    {
        // arrange
        int[] list = [1, 2, 3];

        // assert
        IndexOutOfRangeExceptionExt.ThrowIf(list, 2);
    }

    [TestMethod]
    public void ThrowIf_WithNegativeIndex_ThrowsException()
    {
        // arrange
        int[] list = [];

        // assert
        var ex = Assert.ThrowsException<IndexOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            IndexOutOfRangeExceptionExt.ThrowIf(list, -1));
    }

    [TestMethod]
    public void ThrowIf_WithHigherIndex_ThrowsException()
    {
        // arrange
        int[] list = [1, 2, 3];

        // assert
        var ex = Assert.ThrowsException<IndexOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            IndexOutOfRangeExceptionExt.ThrowIf(list, 8));
    }

    [TestMethod]
    public void ThrowIf_WithIndexZeroAndEmptyList_ThrowsException()
    {
        // arrange
        int[] list = [];

        // assert
        var ex = Assert.ThrowsException<IndexOutOfRangeException>([ExcludeFromCodeCoverage] () =>
            IndexOutOfRangeExceptionExt.ThrowIf(list, 0));
    }

    [TestMethod]
    public void ThrowIf_Null_ThrowsArgumentNullException()
    {
        // arrange
        int[]? list = null;

        // assert
        var ex = Assert.ThrowsException<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            IndexOutOfRangeExceptionExt.ThrowIf(list, 0));
    }
}
