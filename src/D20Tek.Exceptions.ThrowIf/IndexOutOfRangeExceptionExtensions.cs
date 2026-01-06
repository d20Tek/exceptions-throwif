namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="IndexOutOfRangeException"/> to validate index bounds.
/// </summary>
public static class IndexOutOfRangeExceptionExtensions
{
    extension(IndexOutOfRangeException)
    {
        /// <summary>
        /// Throws an <see cref="IndexOutOfRangeException"/> if the specified index is outside the bounds of the collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="list">The collection to validate the index against.</param>
        /// <param name="index">The index to validate.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="list"/> is <c>null</c>.</exception>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when <paramref name="index"/> is less than 0 or greater than or equal to the collection count.
        /// </exception>
        /// <example>
        /// <code>
        /// var list = new string[] { "one", "two", "three" };
        /// IndexOutOfRangeException.ThrowIf(list, 1); // OK
        /// 
        /// // This will throw because index 5 is outside the bounds [0, 2]
        /// IndexOutOfRangeException.ThrowIf(list, 5);
        /// </code>
        /// </example>
        public static void ThrowIf<T>(
            IEnumerable<T>? list,
            int index,
            [CallerArgumentExpression(nameof(index))] string paramName = Constants.NoneParam)
        {
            ArgumentNullException.ThrowIfNull(list, nameof(list));
            if (index < 0 || index >= list.Count())
            {
                throw CreateException(list, index, paramName);
            }
        }

        private static IndexOutOfRangeException CreateException<T>(IEnumerable<T> list, int index, string paramName) =>
            new(string.Format(Constants.IndexRangeMessage, index, list, paramName));
    }
}
