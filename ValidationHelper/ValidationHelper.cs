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
    /// This function returns a boolean representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">Value to convert</param>
    /// <param name="defaultValue">Default value</param>
    /// <returns>Boolean representation of an object. If the conversion is not possible, it returns the specified default value.</returns>
    public static bool GetBoolean(object value, bool defaultValue)
    {
        if (IsNull(value))
        {
            return defaultValue;
        }            

        if (IsBoolean(value))
        {
            return Convert.ToBoolean(value);
        }            

        if (IsStringBoolean(GetString(value, String.Empty)))
        {
            return GetBooleanFromString(value.ToString()!, defaultValue);
        }            

        bool flag;
        try
        {
            flag = Convert.ToBoolean(value);
        }
        catch
        {
            return defaultValue;
        }
        return flag;
    }

    /// <summary>
    /// This function returns a datetime representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">Value to convert</param>
    /// <param name="defaultValue">Default value</param>
    /// <returns>Datetime representation of an object. If the conversion is not possible, it returns the specified default value.</returns>
    public static DateTime GetDateTime(object value, DateTime defaultValue)
    {
        if (IsNull(value))
        {
            return defaultValue;
        }            

        if (IsDateTime(value))
        {
            return Convert.ToDateTime(value);
        }            

        DateTime dateTime;
        try
        {
            dateTime = DateTime.Parse(value.ToString()!);
        }
        catch
        {
            dateTime = defaultValue;
        }
        return dateTime;
    }

    /// <summary>
    /// This function returns a decimal representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if conversion fails.</param>
    /// <returns>Decimal representation of an object. If the conversion is not possible, it returns the specified default value.</returns>
    public static decimal GetDecimal(object value, decimal defaultValue) =>
        IsDecimal(value)
            ? Convert.ToDecimal(value)
            : defaultValue;

    /// <summary>
    /// This function returns a double representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if conversion fails.</param>
    /// <returns>Double representation of an object. If the conversion is not possible, it returns the specified default value.</returns>
    public static double GetDouble(object value, double defaultValue) =>
        IsDouble(value)
            ? Convert.ToDouble(value)
            : defaultValue;

    /// <summary>
    /// This function returns a guid representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if conversion fails.</param>
    /// <returns>Guid representation of an object. If the conversion is not possible, it returns the specified default value.</returns>
    public static Guid GetGuid(object value, Guid defaultValue) =>
        IsGuid(value)
            ? new Guid(value.ToString()!)
            : defaultValue;

    /// <summary>
    /// This function returns an integer representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if conversion fails.</param>
    /// <returns>Integer representation of an object. If the conversion is not possible, it returns the specified default value.</returns>
    public static int GetInteger(object value, int defaultValue) =>
        IsInteger(value)
            ? Convert.ToInt32(value)
            : defaultValue;

    /// <summary>
    /// This function returns a long representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if conversion fails.</param>
    /// <returns>Long representation of an object. If the conversion is not possible, it returns the specified default value.</returns>
    public static long GetLong(object value, long defaultValue) =>
        IsLong(value)
            ? Convert.ToInt64(value)
            : defaultValue;

    /// <summary>
    /// This function returns a string representation of an object. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if conversion fails.</param>
    /// <returns>String representation of an object. If the conversion is not possible, it returns the specified default value.</returns>
    public static string GetString(object value, string defaultValue) =>
        IsNull(value)
            ? defaultValue
            : Convert.ToString(value)!;

    /// <summary>
    /// This function returns a formatted string representation of an object. If the format is null or empty, the function calls the default GetString function. If the conversion is not possible, it returns the specified default value.
    /// </summary>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if conversion fails.</param>
    /// <param name="format">The format value.</param>
    /// <returns>Formatted string representation of an object. If the format is null or empty, the function calls the default GetString function. If the conversion is not possible, it returns the specified default value.</returns>
    public static string GetString(object value, string defaultValue, string format)
    {
        if (IsNull(format))
        {
            return GetString(value, defaultValue);
        }            

        return IsNull(value)
            ? defaultValue
            : String.Format(format, value);
    }

    /// <summary>
    /// This function returns true if the value is a boolean, or it returns false.
    /// </summary>
    /// <param name="value">The object to evaluate.</param>
    /// <returns>True if the specified object can be interpreted as a boolean value; otherwise, it returns false.</returns>
    public static bool IsBoolean(object value)
    {
        if (IsNull(value))
        {
            return false;
        }            

        if (value is bool)
        {
            return true;
        }            

        if (IsStringBoolean(value.ToString()!))
        {
            return true;
        }            

        return false;
    }

    /// <summary>
    /// This function returns true if the value is a datetime, or it returns false.
    /// </summary>
    /// <param name="value">The object to evaluate.</param>
    /// <returns>True if the specified object can be interpreted as a datetime value; otherwise, it returns false.</returns>
    public static bool IsDateTime(object value)
    {
        if (IsNull(value))
        {
            return false;
        }

        if (value is DateTime)
        {
            return true;
        }            

        return DateTime.TryParse(value.ToString(), out _);
    }

    /// <summary>
    /// This function returns true if the value is a decimal, or it returns false.
    /// </summary>
    /// <param name="value">The object to evaluate.</param>
    /// <returns>True if the specified object can be interpreted as a decimal value; otherwise, it returns false.</returns>
    public static bool IsDecimal(object value) =>
        IsNull(value)
            ? false
            : decimal.TryParse(Convert.ToString(value), out _);

    /// <summary>
    /// This function returns true if the value is a double, or it returns false.
    /// </summary>
    /// <param name="value">The object to evaluate.</param> 
    /// <returns>True if the specified object can be interpreted as a double value; otherwise, it returns false.</returns>
    public static bool IsDouble(object value) =>
        IsNull(value)
            ? false
            : double.TryParse(Convert.ToString(value), out _);

    /// <summary>
    /// This function returns true if the value is a guid, or it returns false.
    /// </summary>
    /// <param name="value">The object to evaluate.</param> 
    /// <returns>True if the specified object can be interpreted as a guid value; otherwise, it returns false.</returns>
    public static bool IsGuid(object value)
    {
        if (IsNull(value))
        {
            return false;
        }            

        if (value is Guid)
        {
            return true;
        }            

        var stringValue = value.ToString();
        if (stringValue!.Length != 36)
        {
            return false;
        }            

        return Guid.TryParse(stringValue, out _);
    }

    /// <summary>
    /// This function returns true if the value is an integer, or it returns false.
    /// </summary>
    /// <param name="value">The object to evaluate.</param>
    /// <returns>True if the specified object can be interpreted as a integer value; otherwise, it returns false.</returns>
    public static bool IsInteger(object value) =>
        IsNull(value)
            ? false
            : int.TryParse(Convert.ToString(value), out _);

    /// <summary>
    /// This function returns true if the value is within a specified range, or it returns false.
    /// </summary>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <param name="value">The value to evaluate.</param>
    /// <returns>True if the value is within a specified range; otherwise, it returns false.</returns>
    public static bool IsInRange(int min, int max, int value) =>
        min <= value && value <= max;

    /// <summary>
    /// This function returns true if the value is within a specified range, or it returns false.
    /// </summary>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <param name="value">The value to evaluate.</param>
    /// <returns>True if the value is within a specified range; otherwise, it returns false.</returns>
    public static bool IsInRange(double min, double max, double value) =>
        min <= value && value <= max;

    /// <summary>
    /// This function returns true if the value is within a specified range, or it returns false.
    /// </summary>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <param name="value">The value to evaluate.</param>
    /// <returns>True if the value is within a specified range; otherwise, it returns false.</returns>
    public static bool IsInRange(decimal min, decimal max, decimal value) =>
        min <= value && value <= max;

    /// <summary>
    /// This function returns true if the value is a long, or it returns false.
    /// </summary>
    /// <param name="value">The object to evaluate.</param>
    /// <returns>True if the specified object can be interpreted as a long value; otherwise, it returns false.</returns>
    public static bool IsLong(object value) =>
        IsNull(value)
            ? false
            : long.TryParse(Convert.ToString(value), out _);

    /// <summary>
    /// This function returns true if the value is null, or it returns false.    
    /// </summary>
    /// <param name="value">The object to evaluate.</param>
    /// <returns>True if the specified object can be interpreted as a null value; otherwise, it returns false.</returns>
    public static bool IsNull(object value) =>
        value is null;

    /// <summary>
    /// This function returns true if the value is a positive number, or it returns false.    
    /// </summary>
    /// <param name="value">The object to evaluate.</param>
    /// <returns>True if the specified object is a positive number; otherwise, it returns false.</returns>    
    public static bool IsPositiveNumber(object value)
    {
        if (IsNull(value))
        {
            return false;
        }            

        if (GetDouble(value, -1) >= 0)
        {
            return true;
        }            

        return GetDecimal(value, -1) >= decimal.Zero;
    }

    /// <summary>
    /// This function returns true for "true", "1", "false" or "0", or it returns false.
    /// </summary>
    /// <param name="value">The object to evaluate.</param>
    /// <returns>True if the input is "true", "1", "false" or "0"; otherwise, it returns false.</returns>
    private static bool IsStringBoolean(string value)
    {
        if (IsNull(value))
        {
            return false;
        }            

        var lowerInvariant = value.ToLowerInvariant();
        if (lowerInvariant == "true" || lowerInvariant == "1")
        {
            return true;
        }            

        if (lowerInvariant == "false" || lowerInvariant == "0")
        {
            return true;
        }            

        return false;
    }

    /// <summary>
    /// This function returns true for "true" and "1", returns false for "false" or "0"; otherwise, it returns the specified default value.
    /// </summary>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if conversion fails.</param>
    /// <returns>True if the input is "true" or "1", returns false if the input is "false" or "0"; otherwise, it returns the specified default value.</returns>
    private static bool GetBooleanFromString(string value, bool defaultValue)
    {
        if (IsNull(value))
        {
            return defaultValue;
        }            

        var lowerInvariant = value.ToLowerInvariant();
        if (lowerInvariant == "true" || lowerInvariant == "1")
        {
            return true;
        }            

        if (lowerInvariant == "false" || lowerInvariant == "0")
        {
            return false;
        }            

        return defaultValue;
    }
}
