namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="ArgumentException"/> to validate arguments.
/// </summary>
public static class ArgumentExceptionExtensions
{
    extension(ArgumentException)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified type is not assignable to the target type.
        /// </summary>
        /// <typeparam name="TBase">The base type or interface to check assignability against.</typeparam>
        /// <param name="type">The type to check for assignability.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="type"/> is not assignable to <typeparamref name="TBase"/>.</exception>
        /// <example>
        /// <code>
        /// // Validate that FileStream is assignable to Stream
        /// ArgumentException.ThrowIfNotAssignableTo&lt;Stream&gt;(typeof(FileStream));
        /// </code>
        /// </example>
        public static void ThrowIfNotAssignableTo<TBase>(
            Type type,
            [CallerArgumentExpression(nameof(type))] string? paramName = Constants.NoneParam)
        {
            ArgumentNullException.ThrowIfNull(type, paramName);
            if (!typeof(TBase).IsAssignableFrom(type))
            {
                ThrowNotAssignableTo(
                    type.FullName,
                    typeof(TBase).FullName,
                    paramName,
                    Constants.Argument_TypeNotAssignable);
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the path contains invalid characters.
        /// </summary>
        /// <param name="path">The path to validate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <exception cref="ArgumentException">Thrown when path is invalid.</exception>
        public static void ThrowIfInvalidPath(
            string path,
            [CallerArgumentExpression(nameof(path))] string? paramName = Constants.NoneParam)
        {
            ArgumentNullException.ThrowIfNull(path, paramName);
            
            var directory = Path.GetDirectoryName(path);
            if (directory?.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                throw new ArgumentException(string.Format(Constants.InvalidPath, paramName), paramName);
            }

            var filename = Path.GetFileName(path)!;
            if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                throw new ArgumentException(string.Format(Constants.InvalidPath, paramName), paramName);
            }
        }

        [DoesNotReturn]
        private static void ThrowNotAssignableTo(
            string? typeName,
            string? assignableTo,
            string? paramName,
            string messageFormat) =>
            throw new ArgumentException(string.Format(messageFormat, paramName, typeName, assignableTo), paramName);
    }
}
