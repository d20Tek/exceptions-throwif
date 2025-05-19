using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class IndexOutOfRangeExceptionExt
{
    public static void ThrowIf<T>(
        IEnumerable<T>? list, int index, [CallerArgumentExpression(nameof(index))] string paramName = "none")
    {
        ArgumentNullException.ThrowIfNull(list, nameof(list));
        if (index < 0 || index >= list.Count())
            throw CreateException(list, index, paramName);
    }

    private const string IndexRangeMessage =
        "The parameter '{0}' with index '{1}' was outside the bounds of the list {2}.";

    private static IndexOutOfRangeException CreateException<T>(IEnumerable<T> list, int index, string paramName) =>
        new(string.Format(IndexRangeMessage, index, list, paramName));
}
