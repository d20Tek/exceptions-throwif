using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class KeyNotFoundExtTests
{
    [TestMethod]
    public void ThrowIf_WithExistingKey_DoesNotThrowException()
    {
        // arrange
        var dict = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 }
        };

        // assert
        KeyNotFoundExt.ThrowIf(dict, "two");
    }

    [TestMethod]
    public void ThrowIf_WithMissingKey_ThrowsException()
    {
        // arrange
        var dict = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 }
        };

        // assert
        var ex = Assert.ThrowsException<KeyNotFoundException>([ExcludeFromCodeCoverage] () =>
            KeyNotFoundExt.ThrowIf(dict, "ten"));
    }

    [TestMethod]
    public void ThrowIf_WithEmptyDictionary_ThrowsException()
    {
        // arrange
        var dict = new Dictionary<string, int>();

        // assert
        var ex = Assert.ThrowsException<KeyNotFoundException>([ExcludeFromCodeCoverage] () =>
            KeyNotFoundExt.ThrowIf(dict, "one"));
    }

    [TestMethod]
    public void ThrowIf_WithNullDictionary_ThrowsException()
    {
        // arrange
        Dictionary<string, int>? dict = null;

        // assert
        var ex = Assert.ThrowsException<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            KeyNotFoundExt.ThrowIf(dict, "one"));
    }
}
