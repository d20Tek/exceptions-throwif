using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class ArgumentNullExceptionExt : ArgumentNullException
{
    public static void ThrowIfNullOrEmpty<T>(
        IEnumerable<T>? value, [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
        if (value.Any() is false)
            throw new ArgumentException(string.Format(Constants.CollectionEmpty, paramName), paramName);
    }

    public static void ThrowIfNullOrEmpty<TKey, TValue>(
        IDictionary<TKey, TValue> value,
        [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
        if (value.Any() is false)
            throw new ArgumentException(string.Format(Constants.DictionaryEmpty, paramName), paramName);
    }

    public static void ThrowIfNullOrDefault<T>(
        T? value, [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
        if (EqualityComparer<T>.Default.Equals(value, default!))
            throw new ArgumentException(string.Format(Constants.TypeDefault, paramName), paramName);
    }
}
