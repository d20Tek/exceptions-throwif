global using System.Diagnostics.CodeAnalysis;
global using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

internal static class Constants
{
    public const string NoneParam = "none";

    public const string Argument_TypeNotAssignable = "Parameter {0} with type '{1}' must be assignable to '{2}'.";
    public const string CollectionEmpty = "The collection with parameter name '{0}' cannot be empty.";
    public const string DictionaryEmpty = "The dictionary with parameter name '{0}' cannot be empty.";
    public const string TypeDefault = "The type with parameter name '{0}' cannot be the default value.";
    public const string ArgumentOutOfRange_MinMax = "The value for min '{0}' must be less than or equal to max '{1}'.";
    public const string ArgumentOutOfRange_MustBeInRange =
        "The value '{0}' for parameter '{1}' must be in the range [{2}, {3}].";
    public const string ArgumentOutOfRange_MustBeInRangeExclusive =
        "The value '{0}' for parameter '{1}' must be in the range ({2}, {3}) - excluding the min max.";
    public const string IndexRangeMessage =
        "The parameter '{0}' with index '{1}' was outside the bounds of the list {2}.";
    public const string InvalidEnumMessage = "The parameter {0} has an invalid value for enum type {1}: {2}.";
    public const string DictionaryKeyMissing =
        "The key with parameter name '{0}' and value '{1}' was not found in the dictionary.";
    public const string DisposedExceptionMessage = "The object named '{0}' has alread been disposed.";
    public const string InvalidFormat = "The parameter '{0}' has an invalid format for type {1}: '{2}'.";
    public const string UnauthorizedAccess = "Access to resource '{0}' is denied.";
    public const string InvalidPath = "The path parameter '{0}' contains invalid characters.";
    public const string MustBeNonNegative = "The parameter '{0}' must be non-negative. Value: {1}.";
    public const string MustBePositive = "The parameter '{0}' must be positive. Value: {1}.";
}
