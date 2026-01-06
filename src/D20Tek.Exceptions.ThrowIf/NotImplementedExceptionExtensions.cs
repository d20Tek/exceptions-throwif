using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Exceptions.ThrowIf;

public static class NotImplementedExceptionExtensions
{
    extension(NotImplementedException)
    {
        [DoesNotReturn]
        public static void Throw() => throw new NotImplementedException();
    }
}