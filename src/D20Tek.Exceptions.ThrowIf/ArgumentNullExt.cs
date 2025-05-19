using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class ArgumentNullExceptionExt : ArgumentNullException
{
    public static void ThrowIfNullOrEmpty<T>(
        IEnumerable<T>? value, [CallerArgumentExpression(nameof(value))] string paramName = "none")
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
        if (value.Any() is false)
            throw new ArgumentException(string.Format(CollectionEmpty, paramName), paramName);
    }

    public static void ThrowIfNullOrEmpty<TKey, TValue>(
        IDictionary<TKey, TValue> value, [CallerArgumentExpression(nameof(value))] string paramName = "none")
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
        if (value.Any() is false)
            throw new ArgumentException(string.Format(DictionaryEmpty, paramName), paramName);
    }

    public static void ThrowIfNullOrDefault<T>(
        T? value, [CallerArgumentExpression(nameof(value))] string paramName = "none")
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
        if (EqualityComparer<T>.Default.Equals(value, default!))
            throw new ArgumentException(string.Format(TypeDefault, paramName), paramName);
    }

    private const string CollectionEmpty = "The collection with parameter name '{0}' cannot be empty.";
    private const string DictionaryEmpty = "The dictionary with parameter name '{0}' cannot be empty.";
    private const string TypeDefault = "The type with parameter name '{0}' cannot be the default value.";
}
