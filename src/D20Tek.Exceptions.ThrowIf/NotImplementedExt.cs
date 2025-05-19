namespace D20Tek.Exceptions.ThrowIf;

public class NotImplementedExceptionExt : NotImplementedException
{
    public static void Throw() => throw new NotImplementedException();
}
