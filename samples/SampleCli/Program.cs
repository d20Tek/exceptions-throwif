using D20Tek.Exceptions.ThrowIf;

Console.WriteLine("ThrowIf Samples...");

// Assignable type checks
ArgumentException.ThrowIfNotAssignableTo<Stream>(typeof(FileStream));

try
{
    ArgumentException.ThrowIfNotAssignableTo<ICloneable>(typeof(FileStream));
}
catch (ArgumentException) { }

// list null or empty checks
var list = new string[] { "one", "two", "three"};
ArgumentNullException.ThrowIfNullOrEmpty(list);

try
{
    var empty = Array.Empty<string>();
    ArgumentNullException.ThrowIfNullOrEmpty(empty);
}
catch (ArgumentException) { }

// dictionary null or empty checks
var dict = new Dictionary<string, int>
{
    { "one", 1 }, { "two", 2 }, { "three", 3 }
};
ArgumentNullException.ThrowIfNullOrEmpty(dict);

try
{
    var empty = new Dictionary<string, int>();
    ArgumentNullException.ThrowIfNullOrEmpty(empty);
}
catch (ArgumentException) { }

// value null or default checks
var text = "test string";
ArgumentNullException.ThrowIfNullOrDefault(text);

try
{
    int x = 0;
    ArgumentNullException.ThrowIfNullOrDefault(x);
}
catch (ArgumentException) { }

// argument out of range
ArgumentOutOfRangeException.ThrowIfOutOfRange(5, 1, 10);

try
{
    ArgumentOutOfRangeException.ThrowIfOutOfRange(15, 1, 10);
}
catch (ArgumentOutOfRangeException) { }

// argument out of range (exclusive
ArgumentOutOfRangeException.ThrowIfOutOfRangeExclusive(5, 1, 10);

try
{
    ArgumentOutOfRangeException.ThrowIfOutOfRangeExclusive(10, 1, 10);
}
catch (ArgumentOutOfRangeException) { }

// list index out of range checks
IndexOutOfRangeException.ThrowIf(list, 1);

try
{
    IndexOutOfRangeException.ThrowIf(list, 5);
}
catch (IndexOutOfRangeException) { }

// dictionary key checks
KeyNotFoundException.ThrowIf(dict, "two");

try
{
    KeyNotFoundException.ThrowIf(dict, "none");
}
catch (KeyNotFoundException) { }

// not implemented exception
try
{
    NotImplementedException.Throw();
}
catch (NotImplementedException) { }

// basic exception ThrowIf
try
{
    Exception.ThrowIf<MyException>(true, "should throw custom extension");
}
catch (MyException) { }

public class MyException(string message) : Exception(message)
{
}