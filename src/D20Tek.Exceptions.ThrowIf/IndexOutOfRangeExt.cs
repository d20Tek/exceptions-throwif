using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class IndexOutOfRangeExceptionExt
{
    public static void ThrowIf<T>(
        IEnumerable<T>? list,
        int index,
        [CallerArgumentExpression(nameof(index))] string paramName = Constants.NoneParam)
    {
        ArgumentNullException.ThrowIfNull(list, nameof(list));
        if (index < 0 || index >= list.Count())
            throw CreateException(list, index, paramName);
    }

    private static IndexOutOfRangeException CreateException<T>(IEnumerable<T> list, int index, string paramName) =>
        new(string.Format(Constants.IndexRangeMessage, index, list, paramName));
}
