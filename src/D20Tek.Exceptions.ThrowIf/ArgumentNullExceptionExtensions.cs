using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="ArgumentNullException"/> to validate null or empty arguments.
/// </summary>
public static class ArgumentNullExceptionExtensions
{
    extension(ArgumentNullException)
    {
        /// <summary>
        /// Throws an exception if the specified collection is <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="value">The collection to validate.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
        /// <example>
        /// <code>
        /// var list = new int[] { 3, 7, 5, 9 };
        /// ArgumentNullException.ThrowIfNullOrEmpty(list);
        /// </code>
        /// </example>
        public static void ThrowIfNullOrEmpty<T>(
            IEnumerable<T>? value,
            [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
        {
            ArgumentNullException.ThrowIfNull(value, paramName);
            if (value.Any() is false)
            {
                throw new ArgumentException(string.Format(Constants.CollectionEmpty, paramName), paramName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified dictionary is <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="value">The dictionary to validate.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
        /// <example>
        /// <code>
        /// var dict = new Dictionary&lt;string, int&gt; { { "one", 1 }, { "two", 2 } };
        /// ArgumentNullException.ThrowIfNullOrEmpty(dict);
        /// </code>
        /// </example>
        public static void ThrowIfNullOrEmpty<TKey, TValue>(
            IDictionary<TKey, TValue> value,
            [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
        {
            ArgumentNullException.ThrowIfNull(value, paramName);
            if (value.Any() is false)
            {
                throw new ArgumentException(string.Format(Constants.DictionaryEmpty, paramName), paramName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified value is <c>null</c> or equal to its default value.
        /// </summary>
        /// <typeparam name="T">The type of the value to validate.</typeparam>
        /// <param name="value">The value to validate.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> equals its default value.</exception>
        /// <example>
        /// <code>
        /// var text = "test string";
        /// ArgumentNullException.ThrowIfNullOrDefault(text);
        /// 
        /// int x = 0; // This will throw because 0 is the default for int
        /// ArgumentNullException.ThrowIfNullOrDefault(x);
        /// </code>
        /// </example>
        public static void ThrowIfNullOrDefault<T>(
            T? value,
            [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
        {
            ArgumentNullException.ThrowIfNull(value, paramName);
            if (EqualityComparer<T>.Default.Equals(value, default!))
            {
                throw new ArgumentException(string.Format(Constants.TypeDefault, paramName), paramName);
            }
        }
    }
}
