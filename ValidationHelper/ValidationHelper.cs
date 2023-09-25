namespace ValidationHelper;

/// <summary>
/// A class library offering a wide range of validation methods.
/// </summary>
/// <author>
/// Stuart Shepherd
/// </author>
/// <website>
/// https://stuartshepherd.com
/// </website>

public class ValidationHelper
{
    /// <summary>
    /// This function returns a decimal representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    public static decimal GetDecimal(object value, decimal defaultValue) =>
        IsDecimal(value)
            ? Convert.ToDecimal(value)
            : defaultValue;

    /// <summary>
    /// This function returns a double representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    public static double GetDouble(object value, double defaultValue) =>
        IsDouble(value)
            ? Convert.ToDouble(value)
            : defaultValue;

    /// <summary>
    /// This function returns an integer representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    public static int GetInteger(object value, int defaultValue) =>
        IsInteger(value)
            ? Convert.ToInt32(value)
            : defaultValue;

    /// <summary>
    /// This function returns a string representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    public static string GetString(object value, string defaultValue) =>
        IsNull(value) 
            ? defaultValue 
            : Convert.ToString(value)!;

    /// <summary>
    /// This function returns true if the value is a decimal, or it returns false.
    /// </summary>
    public static bool IsDecimal(object value) =>
        IsNull(value)
            ? false
            : decimal.TryParse(Convert.ToString(value), out _);

    /// <summary>
    /// This function returns true if the value is a double, or it returns false.
    /// </summary>
    public static bool IsDouble(object value) =>
        IsNull(value)
            ? false
            : double.TryParse(Convert.ToString(value), out _);

    /// <summary>
    /// This function returns true if the value is an integer, or it returns false.
    /// </summary>
    public static bool IsInteger(object value) =>
        IsNull(value) 
            ? false 
            : int.TryParse(Convert.ToString(value), out _);

    /// <summary>
    /// This function returns true if the value is a long, or it returns false.
    /// </summary>
    public static bool IsLong(object value) =>
        IsNull(value)
            ? false
            : long.TryParse(Convert.ToString(value), out _);

    /// <summary>
    /// This function returns true if the value is null, or it returns false.
    /// </summary>
    public static bool IsNull(object value) =>
        value is null;
}
