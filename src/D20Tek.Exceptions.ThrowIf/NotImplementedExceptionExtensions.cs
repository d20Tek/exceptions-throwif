using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="NotImplementedException"/> to indicate unimplemented functionality.
/// </summary>
public static class NotImplementedExceptionExtensions
{
    extension(NotImplementedException)
    {
        /// <summary>
        /// Throws a <see cref="NotImplementedException"/> to indicate that a feature is not implemented.
        /// </summary>
        /// <exception cref="NotImplementedException">Always thrown.</exception>
        /// <example>
        /// <code>
        /// public void FutureFeature()
        /// {
        ///     NotImplementedException.Throw();
        /// }
        /// </code>
        /// </example>
        [DoesNotReturn]
        public static void Throw() => throw new NotImplementedException();
    }
}