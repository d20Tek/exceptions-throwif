using System.Security.Claims;

namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="UnauthorizedAccessException"/> to validate an authorized user.
/// </summary>
public static class UnauthorizedAccessExceptionExtensions
{
    extension(UnauthorizedAccessException)
    {
        /// <summary>
        /// Throws an <see cref="UnauthorizedAccessException"/> if the user lacks permission.
        /// </summary>
        /// <param name="hasPermission">Whether the user has permission.</param>
        /// <param name="resource">The resource being accessed.</param>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        public static void ThrowIfUnauthorized(bool hasPermission, string resource)
        {
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException(string.Format(Constants.UnauthorizedAccess, resource));
            }
        }

        /// <summary>
        /// Throws an <see cref="UnauthorizedAccessException"/> if the user lacks permission.
        /// </summary>
        /// <param name="user">The user to validate has permission.</param>
        /// <param name="role">The user role to validate.</param>
        /// <param name="resource">The resource being accessed.</param>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        public static void ThrowIfUnauthorized(ClaimsPrincipal user, string role, string resource) =>
            ThrowIfUnauthorized(user.Identity?.IsAuthenticated is false || user.IsInRole(role) is false, resource);
    }
}