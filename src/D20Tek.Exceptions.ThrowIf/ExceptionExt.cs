namespace D20Tek.Exceptions.ThrowIf;

public class ExceptionExt : Exception
{
    public static void ThrowIf<TException>(bool condition, string message)
        where TException : Exception
    {
        if (condition)
        {
            var exception = (TException?)Activator.CreateInstance(typeof(TException), message);
            throw exception!;
        }
    }

    public static void ThrowIfNot<TException>(bool condition, string message)
        where TException : Exception =>
        ThrowIf<TException>(!condition, message);


    public static void ThrowIf<TException>(Func<bool> condition, string message)
        where TException : Exception =>
        ThrowIf<TException>(condition(), message);

    public static void ThrowIfNot<TException>(Func<bool> condition, string message)
        where TException : Exception =>
        ThrowIf<TException>(!condition(), message);
}
