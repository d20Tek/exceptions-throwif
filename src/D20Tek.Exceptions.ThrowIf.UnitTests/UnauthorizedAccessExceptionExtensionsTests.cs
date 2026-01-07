using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace D20Tek.Exceptions.ThrowIf.UnitTests;

[TestClass]
public class UnauthorizedAccessExceptionExtensionsTests
{
    [TestMethod]
    public void ThrowIfUnauthorized_WithPermission_DoesNotThrow()
    {
        // arrange
        bool hasPermission = true;
        string resource = "TestResource";

        // act - assert
        UnauthorizedAccessException.ThrowIfUnauthorized(hasPermission, resource);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithoutPermission_ThrowsUnauthorizedAccessException()
    {
        // arrange
        bool hasPermission = false;
        string resource = "TestResource";

        // act
        var ex = Assert.ThrowsExactly<UnauthorizedAccessException>([ExcludeFromCodeCoverage] () =>
            UnauthorizedAccessException.ThrowIfUnauthorized(hasPermission, resource));

        // assert
        Assert.Contains("TestResource", ex.Message);
        Assert.Contains("denied", ex.Message);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithAuthenticatedUserInRole_DoesNotThrow()
    {
        // arrange
        var identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, "TestUser"),
                new Claim(ClaimTypes.Role, "Admin")
            ],
            "TestAuthType");
        var user = new ClaimsPrincipal(identity);
        string role = "Admin";
        string resource = "AdminResource";

        // act - assert
        UnauthorizedAccessException.ThrowIfUnauthorized(user, role, resource);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithAuthenticatedUserNotInRole_ThrowsUnauthorizedAccessException()
    {
        // arrange
        var identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, "TestUser"),
                new Claim(ClaimTypes.Role, "User")
            ],
            "TestAuthType");
        var user = new ClaimsPrincipal(identity);
        string role = "Admin";
        string resource = "AdminResource";

        // act
        var ex = Assert.ThrowsExactly<UnauthorizedAccessException>([ExcludeFromCodeCoverage] () =>
            UnauthorizedAccessException.ThrowIfUnauthorized(user, role, resource));

        // assert
        Assert.Contains("AdminResource", ex.Message);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithUnauthenticatedUser_ThrowsUnauthorizedAccessException()
    {
        // arrange
        var identity = new ClaimsIdentity(); // Not authenticated
        var user = new ClaimsPrincipal(identity);
        string role = "Admin";
        string resource = "SecureResource";

        // act
        var ex = Assert.ThrowsExactly<UnauthorizedAccessException>([ExcludeFromCodeCoverage] () =>
            UnauthorizedAccessException.ThrowIfUnauthorized(user, role, resource));

        // assert
        Assert.Contains("SecureResource", ex.Message);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithNullIdentity_ThrowsUnauthorizedAccessException()
    {
        // arrange
        var user = new ClaimsPrincipal();
        string role = "Admin";
        string resource = "SecureResource";

        // act
        var ex = Assert.ThrowsExactly<UnauthorizedAccessException>([ExcludeFromCodeCoverage] () =>
            UnauthorizedAccessException.ThrowIfUnauthorized(user, role, resource));

        // assert
        Assert.Contains("SecureResource", ex.Message);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithMultipleRolesIncludingRequiredRole_DoesNotThrow()
    {
        // arrange
        var identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, "TestUser"),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Manager")
            ],
            "TestAuthType");
        var user = new ClaimsPrincipal(identity);
        string role = "Admin";
        string resource = "AdminResource";

        // act - assert
        UnauthorizedAccessException.ThrowIfUnauthorized(user, role, resource);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithMultipleRolesNotIncludingRequiredRole_ThrowsUnauthorizedAccessException()
    {
        // arrange
        var identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, "TestUser"),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Role, "Manager")
            ],
            "TestAuthType");
        var user = new ClaimsPrincipal(identity);
        string role = "Admin";
        string resource = "AdminResource";

        // act
        var ex = Assert.ThrowsExactly<UnauthorizedAccessException>([ExcludeFromCodeCoverage] () =>
            UnauthorizedAccessException.ThrowIfUnauthorized(user, role, resource));

        // assert
        Assert.Contains("AdminResource", ex.Message);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithEmptyResourceName_ThrowsWithEmptyResourceInMessage()
    {
        // arrange
        bool hasPermission = false;
        string resource = "";

        // act
        var ex = Assert.ThrowsExactly<UnauthorizedAccessException>([ExcludeFromCodeCoverage] () =>
            UnauthorizedAccessException.ThrowIfUnauthorized(hasPermission, resource));

        // assert
        Assert.Contains("denied", ex.Message);
    }

    [TestMethod]
    public void ThrowIfUnauthorized_WithCaseSensitiveRoleName_ThrowsUnauthorizedAccessException()
    {
        // arrange
        var identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, "TestUser"),
                new Claim(ClaimTypes.Role, "admin") // lowercase
            ],
            "TestAuthType");
        var user = new ClaimsPrincipal(identity);
        string role = "Admin"; // uppercase
        string resource = "AdminResource";

        // act
        var ex = Assert.ThrowsExactly<UnauthorizedAccessException>([ExcludeFromCodeCoverage] () =>
            UnauthorizedAccessException.ThrowIfUnauthorized(user, role, resource));

        // assert
        Assert.Contains("AdminResource", ex.Message);
    }
}