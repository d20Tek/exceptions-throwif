using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class ArgumentExceptionExtensionsTests
{
    [TestMethod]
    public void ThrowIfNotAssignableTo_WithSameType_DoesNotThrow()
    {
        // arrange

        // act - assert
        ArgumentException.ThrowIfNotAssignableTo<Stream>(typeof(Stream));
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithAssignableType_DoesNotThrow()
    {
        // arrange

        // act - assert
        ArgumentException.ThrowIfNotAssignableTo<Stream>(typeof(FileStream));
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithUnassignableType_ThrowsException()
    {
        // arrange
        Type checkType = typeof(FileStream);

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfNotAssignableTo<string>(checkType));

        // assert
        Assert.AreEqual("checkType", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithNullType_ThrowsException()
    {
        // arrange
        Type? nullType = null;

        // act
        var ex = Assert.ThrowsExactly<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfNotAssignableTo<string>(nullType!));

        // assert
        Assert.AreEqual("nullType", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithAssignableInterface_DoesNotThrow()
    {
        // arrange

        // act - assert
        ArgumentException.ThrowIfNotAssignableTo<IDisposable>(typeof(FileStream));
    }

    [TestMethod]
    public void ThrowIfNotAssignableTo_WithUnassignableInterface_ThrowsException()
    {
        // arrange

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfNotAssignableTo<ICloneable>(typeof(FileStream)));

        // assert
        Assert.AreEqual("typeof(FileStream)", ex.ParamName);
    }
}
