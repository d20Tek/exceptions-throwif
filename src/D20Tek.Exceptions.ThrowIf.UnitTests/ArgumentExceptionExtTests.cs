using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class ArgumentExceptionExtTests
{
    [TestMethod]
    public void ThrowIfNotAssignableTo_WithSameType_DoesNotThrow()
    {
        // arrange

        // act
        ArgumentExceptionExt.ThrowIfNotAssignableTo<Stream>(typeof(Stream));

        // assert
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithAssignableType_DoesNotThrow()
    {
        // arrange

        // act
        ArgumentExceptionExt.ThrowIfNotAssignableTo<Stream>(typeof(FileStream));

        // assert
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithUnassignableType_ThrowsException()
    {
        // arrange
        Type checkType = typeof(FileStream);

        // act
        var ex = Assert.ThrowsException<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentExceptionExt.ThrowIfNotAssignableTo<string>(checkType));

        // assert
        Assert.AreEqual("checkType", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithNullType_ThrowsException()
    {
        // arrange
        Type? nullType = null;

        // act
        var ex = Assert.ThrowsException<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            ArgumentExceptionExt.ThrowIfNotAssignableTo<string>(nullType!));

        // assert
        Assert.AreEqual("nullType", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithAssignableInterface_DoesNotThrow()
    {
        // arrange

        // act
        ArgumentExceptionExt.ThrowIfNotAssignableTo<IDisposable>(typeof(FileStream));

        // assert
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithUnassignableInterface_ThrowsException()
    {
        // arrange

        // act
        var ex = Assert.ThrowsException<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentExceptionExt.ThrowIfNotAssignableTo<ICloneable>(typeof(FileStream)));

        // assert
        Assert.AreEqual("typeof(FileStream)", ex.ParamName);
    }
}
