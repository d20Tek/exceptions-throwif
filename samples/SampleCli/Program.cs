// See https://aka.ms/new-console-template for more information
using D20Tek.Exceptions.ThrowIf;

Console.WriteLine("ThrowIf Samples...");

// Assignable type checks
ArgumentExceptionExt.ThrowIfNotAssignableTo<Stream>(typeof(FileStream));

try
{
    ArgumentExceptionExt.ThrowIfNotAssignableTo<ICloneable>(typeof(FileStream));
}
catch (ArgumentException) { }

// list null or empty checks
var list = new string[] { "one", "two", "three"};
ArgumentNullExceptionExt.ThrowIfNullOrEmpty(list);

try
{
    var empty = Array.Empty<string>();
    ArgumentNullExceptionExt.ThrowIfNullOrEmpty(empty);
}
catch (ArgumentException) { }

// dictionary null or empty checks
var dict = new Dictionary<string, int>
{
    { "one", 1 }, { "two", 2 }, { "three", 3 }
};
ArgumentNullExceptionExt.ThrowIfNullOrEmpty(dict);

try
{
    var empty = new Dictionary<string, int>();
    ArgumentNullExceptionExt.ThrowIfNullOrEmpty(empty);
}
catch (ArgumentException) { }

// value null or default checks
var text = "test string";
ArgumentNullExceptionExt.ThrowIfNullOrDefault(text);

try
{
    int x = 0;
    ArgumentNullExceptionExt.ThrowIfNullOrDefault(x);
}
catch (ArgumentException) { }

// argument out of range
ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(5, 1, 10);

try
{
    ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRange(15, 1, 10);
}
catch (ArgumentOutOfRangeException) { }

// argument out of range (exclusive
ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRangeExclusive(5, 1, 10);

try
{
    ArgumentOutOfRangeExceptionExt.ThrowIfOutOfRangeExclusive(10, 1, 10);
}
catch (ArgumentOutOfRangeException) { }

// list index out of range checks
IndexOutOfRangeExceptionExt.ThrowIf(list, 1);

try
{
    IndexOutOfRangeExceptionExt.ThrowIf(list, 5);
}
catch (IndexOutOfRangeException) { }

// dictionary key checks
KeyNotFoundExt.ThrowIf(dict, "two");

try
{
    KeyNotFoundExt.ThrowIf(dict, "none");
}
catch (KeyNotFoundException) { }

// not implemented exception
try
{
    NotImplementedExceptionExt.Throw();
}
catch (NotImplementedException) { }

// basic exception ThrowIf
try
{
    ExceptionExt.ThrowIf<MyException>(true, "should throw custom extension");
}
catch (MyException) { }

public class MyException : Exception
{
    public MyException(string message)
        : base(message)
    {
    }
}