using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class NotImplementedExtTests
{
    [TestMethod]
    public void Throw_ThrowsNotImplementedException()
    {
        // arrange

        // assert
        var ex = Assert.ThrowsException<NotImplementedException>([ExcludeFromCodeCoverage] () =>
            NotImplementedExceptionExt.Throw());
    }
}
