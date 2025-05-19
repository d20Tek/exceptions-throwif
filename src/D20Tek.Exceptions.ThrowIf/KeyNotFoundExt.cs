using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class KeyNotFoundExt : KeyNotFoundException
{
    public static void ThrowIf<TKey, TValue>(
        IDictionary<TKey, TValue>? dictionary, TKey key, [CallerArgumentExpression(nameof(key))] string paramName = "none")
    {
        ArgumentNullException.ThrowIfNull(dictionary, nameof(dictionary));
        if (dictionary.ContainsKey(key) is false)
            throw new KeyNotFoundException(string.Format(DictionaryKeyMissing, paramName, key));
    }

    private const string DictionaryKeyMissing = 
        "The key with parameter name '{0}' and value '{1}' was not found in the dictionary.";
}
