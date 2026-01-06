namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="KeyNotFoundException"/> to validate dictionary keys.
/// </summary>
public static class KeyNotFoundExceptionExtensions
{
    extension(KeyNotFoundException)
    {
        /// <summary>
        /// Throws a <see cref="KeyNotFoundException"/> if the specified key is not found in the dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to search for the key.</param>
        /// <param name="key">The key to validate.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dictionary"/> is <c>null</c>.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when <paramref name="key"/> is not found in the dictionary.</exception>
        /// <example>
        /// <code>
        /// var dict = new Dictionary&lt;string, int&gt; { { "one", 1 }, { "two", 2 } };
        /// KeyNotFoundException.ThrowIf(dict, "two"); // OK
        /// 
        /// // This will throw because "three" is not in the dictionary
        /// KeyNotFoundException.ThrowIf(dict, "three");
        /// </code>
        /// </example>
        public static void ThrowIf<TKey, TValue>(
            IDictionary<TKey, TValue>? dictionary,
            TKey key,
            [CallerArgumentExpression(nameof(key))] string paramName = Constants.NoneParam)
        {
            ArgumentNullException.ThrowIfNull(dictionary, nameof(dictionary));
            if (dictionary.ContainsKey(key) is false)
            {
                throw new KeyNotFoundException(string.Format(Constants.DictionaryKeyMissing, paramName, key));
            }
        }
    }
}
