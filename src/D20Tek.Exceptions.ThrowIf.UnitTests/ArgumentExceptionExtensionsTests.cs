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

    [TestMethod]
    public void ThrowIfInvalidPath_WithValidPath_DoesNotThrow()
    {
        // arrange
        string path = @"C:\temp\file.txt";

        // act - assert
        ArgumentException.ThrowIfInvalidPath(path);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithValidRelativePath_DoesNotThrow()
    {
        // arrange
        string path = @"folder\subfolder\file.txt";

        // act - assert
        ArgumentException.ThrowIfInvalidPath(path);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithValidUnixPath_DoesNotThrow()
    {
        // arrange
        string path = "/home/user/documents/file.txt";

        // act - assert
        ArgumentException.ThrowIfInvalidPath(path);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithInvalidCharacters_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\temp\\file<invalid>.txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
        Assert.Contains("path", ex.Message);
        Assert.Contains("invalid", ex.Message);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithPipeCharacter_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\temp\\file|name.txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithQuestionMarkInPath_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\temp\\file?.txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithAsteriskInPath_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\temp\\*.txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithNullPath_ThrowsArgumentNullException()
    {
        // arrange
        string? nullPath = null;

        // act
        var ex = Assert.ThrowsExactly<ArgumentNullException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(nullPath!));

        // assert
        Assert.AreEqual("nullPath", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithEmptyPath_DoesNotThrow()
    {
        // arrange
        string path = "";

        // act - assert
        ArgumentException.ThrowIfInvalidPath(path);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithColonInMiddleOfPath_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\temp\\file:name.txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithQuotesInPath_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\temp\\\"file\".txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithLessThanCharacter_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\temp\\<file>.txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithInvalidFolderChar_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\tem|p\\file.txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithGreaterThanCharacter_ThrowsArgumentException()
    {
        GuardWinOs();

        // arrange
        string path = "C:\\temp\\>file.txt";

        // act
        var ex = Assert.ThrowsExactly<ArgumentException>([ExcludeFromCodeCoverage] () =>
            ArgumentException.ThrowIfInvalidPath(path));

        // assert
        Assert.AreEqual("path", ex.ParamName);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithPathContainingSpaces_DoesNotThrow()
    {
        // arrange
        string path = "C:\\Program Files\\My App\\file.txt";

        // act - assert
        ArgumentException.ThrowIfInvalidPath(path);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithUNCPath_DoesNotThrow()
    {
        // arrange
        string path = @"\\server\share\folder\file.txt";

        // act - assert
        ArgumentException.ThrowIfInvalidPath(path);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithPathContainingDots_DoesNotThrow()
    {
        // arrange
        string path = @"C:\temp\..\other\file.txt";

        // act - assert
        ArgumentException.ThrowIfInvalidPath(path);
    }

    [TestMethod]
    public void ThrowIfInvalidPath_WithValidDirectoryButNoFilename_DoesNotThrow()
    {
        // arrange
        string path = @"C:\temp\folder\other\";

        // act - assert
        ArgumentException.ThrowIfInvalidPath(path);
    }

    [ExcludeFromCodeCoverage]
    private static void GuardWinOs()
    {
        if (!OperatingSystem.IsWindows()) Assert.Inconclusive("Windows-only path rules");
    }
}
