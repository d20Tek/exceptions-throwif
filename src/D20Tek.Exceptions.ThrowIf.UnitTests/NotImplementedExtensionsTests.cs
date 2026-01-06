using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class NotImplementedExtensionsTests
{
    [TestMethod]
    public void Throw_ThrowsNotImplementedException()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsExactly<NotImplementedException>([ExcludeFromCodeCoverage] () =>
            NotImplementedException.Throw());
    }
}
