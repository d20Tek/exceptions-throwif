# exceptions-throwif

## Introduction
Welcome to D20Tek.Exceptions.ThrowIf. This library contains extensions to the ArgumentException.ThrowIf methods to cover more scenarios and additional exception types. It can be used in any .NET project, whether it is a console application, WebApi, or Blazor application.

With the update to .NET 10, we use the new Extension Members feature to add static methods to the base exception type to make the coding experience seamless.

In the future, we may support more exception types and extensions to make Exception throwing easier. If you have suggestions for Exception extensions, please leave feedback in this repo's Issues page.

## Installation
This library is a NuGet package so it is easy to add to your project. To install the package into your solution, you can use the NuGet Package Manager. In PM, please use the following command:

```cmd
PM > Install-Package D20Tek.Exceptions.ThrowIf --version 1.0.1
```

To install in the Visual Studio UI, go to the Tools menu > "Manage NuGet Packages". Then search for D20Tek.Exceptions.ThrowIf, and install whichever packages you require from there.

## Usage
Once you've installed the NuGet package, you can start using it in your .NET projects. It's as easy as using the D20Tek.Exceptions.ThrowIf namespace and calling the exception extension.

Here is an example of using it to check whether an array is null or empty:

```csharp
    var list = new int[] { 3, 7, 5, 9 };

    ArgumentNullException.ThrowIfNullOrEmpty(list);
```

Or throwing an ArgumentOutOfRangeException that checks a value between a min and max range:

```csharp
    var check = 3.14f;

    ArgumentOutOfRangeException.ThrowIfOutOfRange(check, 1.0f, 10.0f);
```

There is also a helper ThrowIf extension that lets you throw any exception type based on a condition. This extension is useful for covering other exceptions that we have not added yet, or for using the ThrowIf syntax with your own custom Exception class.

```csharp
    public class MyCustomException : Exception
    {
        public MyCustomException(string message)
            :base(message) { }
    }

    int v = 12;
    Exception.ThrowIf<MyCustomException>(() => v < 0, "Invalid value, use custom exception");

    Exception.ThrowIf<MyCustomException>(() => v >= 10, "Invalid value, use custom exception - this one throws");
```

Note: the custom exception class must derive from Exception, and it must have at minimum one constructor that takes a message as a string.

## Samples
For more detailed examples on how to use D20Tek.Exceptions.ThrowIf, please review the following samples:

* [SampleCli](samples/SampleCli) - A simple console application that tests out all of the new ThrowIf functions.

## Feedback
If you use this library and have any feedback, bugs, or suggestions, please file them in the Issues section of this repository. I'm still in the process of building the library and samples, so any suggestions that would make it more useable are welcome.
