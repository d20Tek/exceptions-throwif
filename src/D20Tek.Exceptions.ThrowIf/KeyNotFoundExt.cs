using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class KeyNotFoundExt : KeyNotFoundException
{
    public static void ThrowIf<TKey, TValue>(
        IDictionary<TKey, TValue>? dictionary,
        TKey key,
        [CallerArgumentExpression(nameof(key))] string paramName = Constants.NoneParam)
    {
        ArgumentNullException.ThrowIfNull(dictionary, nameof(dictionary));
        if (dictionary.ContainsKey(key) is false)
            throw new KeyNotFoundException(string.Format(Constants.DictionaryKeyMissing, paramName, key));
    }
}
