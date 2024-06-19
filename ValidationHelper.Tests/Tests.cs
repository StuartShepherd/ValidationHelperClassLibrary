namespace ValidationHelper.Tests;

[TestClass]
public class Tests
{
    [TestMethod]
    [DataRow(null, false, false)]
    [DataRow(null, true, true)]
    [DataRow("test", false, false)]
    [DataRow("test", true, true)]
    [DataRow(-1, false, true)]
    [DataRow(0, false, false)]
    [DataRow(1, false, true)]
    [DataRow(2, false, true)]
    [DataRow("false", true, false)]
    [DataRow("true", true, true)]
    [DataRow(false, true, false)]
    [DataRow(false, false, false)]
    public void GetBoolean_FromDataRowTest(object x, bool y, bool expected)
    {
        var actual = ValidationHelper.GetBoolean(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetDateTimeTestData =>
        new[] {            
            new object[] { int.MinValue, DateTime.MinValue, DateTime.MinValue },
            new object[] { int.MaxValue, DateTime.MaxValue, DateTime.MaxValue },
            new object[] { long.MinValue, DateTime.MinValue, DateTime.MinValue },
            new object[] { long.MaxValue, DateTime.MaxValue, DateTime.MaxValue },
            new object[] { decimal.MinValue, DateTime.MinValue, DateTime.MinValue },
            new object[] { decimal.MaxValue, DateTime.MaxValue, DateTime.MaxValue },
            new object[] { DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
            new object[] { DateTime.MaxValue, DateTime.MaxValue, DateTime.MaxValue },
            new object[] { null!, DateTime.MinValue, DateTime.MinValue },
            new object[] { "test", DateTime.MinValue, DateTime.MinValue },
            new object[] { "2023-13-01", DateTime.MinValue, DateTime.MinValue },
            new object[] { "February 29, 2024", DateTime.MinValue, new DateTime(2024, 02, 29) },
            new object[] { "16/05/2023", DateTime.MinValue, new DateTime(2023, 05, 16) },
            new object[] { "2023/05/16", DateTime.MinValue, new DateTime(2023, 05, 16) },
            new object[] { "2023-10-17 10:00:00", DateTime.MinValue, new DateTime(2023, 10, 17, 10, 0, 0) },
        };

    [TestMethod]
    [DynamicData(nameof(GetDateTimeTestData))]
    public void GetDateTime_FromDynamicDataTest(object x, DateTime y, DateTime expected)
    {
        var actual = ValidationHelper.GetDateTime(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetDecimalTestData =>
        new[] {
            new object[] { null!, 1m, 1m },
            new object[] { "test", 1m, 1m },
            new object[] { int.MinValue, 1m, Convert.ToDecimal(int.MinValue) },
            new object[] { int.MaxValue, 1m, Convert.ToDecimal(int.MaxValue) },
            new object[] { long.MinValue, 1m, Convert.ToDecimal(long.MinValue) },
            new object[] { long.MaxValue, 1m, Convert.ToDecimal(long.MaxValue) },
            new object[] { decimal.MinValue, 1m, decimal.MinValue },
            new object[] { decimal.MaxValue, 1m, decimal.MaxValue },
        };

    [TestMethod]
    [DynamicData(nameof(GetDecimalTestData))]
    public void GetDecimal_FromDynamicDataTest(object x, decimal y, decimal expected)
    {
        var actual = ValidationHelper.GetDecimal(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetDoubleTestData =>
        new[] {
            new object[] { null!, 1, 1 },
            new object[] { "test", 1, 1 },
            new object[] { int.MinValue, 1, Convert.ToDouble(int.MinValue) },
            new object[] { int.MaxValue, 1, Convert.ToDouble(int.MaxValue) },
            new object[] { long.MinValue, 1, Convert.ToDouble(long.MinValue) },
            new object[] { long.MaxValue, 1, Convert.ToDouble(long.MaxValue) },
            new object[] { decimal.MinValue, 1, Convert.ToDouble(decimal.MinValue) },
            new object[] { decimal.MaxValue, 1, Convert.ToDouble(decimal.MaxValue) },
            new object[] { double.MinValue, 1, double.MinValue },
            new object[] { double.MaxValue, 1, double.MaxValue },
        };

    [TestMethod]
    [DynamicData(nameof(GetDoubleTestData))]
    public void GetDouble_FromDynamicDataTest(object x, double y, double expected)
    {
        var actual = ValidationHelper.GetDouble(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetGuidTestData =>
        new[] {
                new object[] { null!, new Guid("a5c4c4cb-67f8-407d-8fa7-f59372e5b820"), new Guid("a5c4c4cb-67f8-407d-8fa7-f59372e5b820") },
                new object[] { "test", new Guid("a5c4c4cb-67f8-407d-8fa7-f59372e5b820"), new Guid("a5c4c4cb-67f8-407d-8fa7-f59372e5b820") },
                new object[] { "a5c4c4cb-67f8-407d-8fa7-f59372e5b820", new Guid("0fe38975-f6cd-4ba1-acfb-1cefa9d9c13b"), new Guid("a5c4c4cb-67f8-407d-8fa7-f59372e5b820") },
        };

    [TestMethod]
    [DynamicData(nameof(GetGuidTestData))]
    public void GetGuid_FromDynamicDataTest(object x, Guid y, Guid expected)
    {
        var actual = ValidationHelper.GetGuid(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetIntegerTestData =>
        new[] {
            new object[] { null!, 1, 1 },
            new object[] { "test", 1, 1 },
            new object[] { int.MinValue, 1, int.MinValue },
            new object[] { int.MaxValue, 1, int.MaxValue },
            new object[] { long.MinValue, 1, 1 },
            new object[] { long.MaxValue, 1, 1 },
            new object[] { decimal.MinValue, 1, 1 },
            new object[] { decimal.MaxValue, 1, 1 },
            new object[] { double.MinValue, 1, 1 },
            new object[] { double.MaxValue, 1, 1 },
        };

    [TestMethod]
    [DynamicData(nameof(GetIntegerTestData))]
    public void GetInteger_FromDynamicDataTest(object x, int y, int expected)
    {
        var actual = ValidationHelper.GetInteger(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetLongTestData =>
        new[] {
            new object[] { null!, 1, 1 },
            new object[] { "test", 1, 1 },
            new object[] { int.MinValue, 1, int.MinValue },
            new object[] { int.MaxValue, 1, int.MaxValue },
            new object[] { long.MinValue, 1, long.MinValue },
            new object[] { long.MaxValue, 1, long.MaxValue },
            new object[] { decimal.MinValue, 1, 1 },
            new object[] { decimal.MaxValue, 1, 1 },
            new object[] { double.MinValue, 1, 1 },
            new object[] { double.MaxValue, 1, 1 },
        };

    [TestMethod]
    [DynamicData(nameof(GetLongTestData))]
    public void GetLong_FromDynamicDataTest(object x, long y, long expected)
    {
        var actual = ValidationHelper.GetLong(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetStringTestData =>
        new[] {
            new object[] { null!, "test", "test" },
            new object[] { "test", null!, "test" },
            new object[] { int.MinValue, null!, Convert.ToString(int.MinValue) },
            new object[] { int.MaxValue, null!, Convert.ToString(int.MaxValue) },
            new object[] { long.MinValue, null!, Convert.ToString(long.MinValue) },
            new object[] { long.MaxValue, null!, Convert.ToString(long.MaxValue) },
            new object[] { decimal.MinValue, null!, Convert.ToString(decimal.MinValue) },
            new object[] { decimal.MaxValue, null!, Convert.ToString(decimal.MaxValue) },
            new object[] { DateTime.MinValue, null!, Convert.ToString(DateTime.MinValue) },
        };

    [TestMethod]
    [DynamicData(nameof(GetStringTestData))]
    public void GetString_FromDynamicDataTest(object x, string y, string expected)
    {
        var actual = ValidationHelper.GetString(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetStringFormatTestData =>
        new[] {
            new object[] { "20", null!, "Number is {0}", "Number is 20" },
            new object[] { "Stuart", null!, "My name is {0}", "My name is Stuart" },
            new object[] { "Stuart", "Shepherd", null!, "Stuart" },
            new object[] { null!, "Shepherd", null!, "Shepherd" },
        };

    [TestMethod]
    [DynamicData(nameof(GetStringFormatTestData))]
    public void GetStringFormat_FromDynamicDataTest(object x, string y, string z, string expected)
    {
        var actual = ValidationHelper.GetString(x, y, z);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(null, false)]
    [DataRow(2, false)]
    [DataRow("test", false)]
    [DataRow(0, true)]
    [DataRow(1, true)]
    [DataRow("false", true)]
    [DataRow("true", true)]
    [DataRow(true, true)]
    [DataRow(false, true)]
    public void IsBoolean_FromDataRowTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsBoolean(x);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> IsDateTimeTestData =>
        new[] {
            new object[] { int.MinValue, false },
            new object[] { int.MaxValue, false },
            new object[] { long.MinValue, false },
            new object[] { long.MaxValue, false },
            new object[] { double.MinValue, false },
            new object[] { double.MaxValue, false },
            new object[] { decimal.MinValue, false },
            new object[] { decimal.MaxValue, false },
            new object[] { null!, false },
            new object[] { "2023-13-01", false },
            new object[] { "February 29, 2024", true },
            new object[] { DateTime.MinValue, true },
            new object[] { DateTime.MaxValue, true },
            new object[] { "16/05/2023", true },
            new object[] { "2023/05/16", true },
            new object[] { "2023-10-17 10:00:00", true },
        };

    [TestMethod]
    [DynamicData(nameof(IsDateTimeTestData))]
    public void IsDateTime_FromDynamicDataTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsDateTime(x);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(null, false)]
    [DataRow("test", false)]
    [DataRow(3.1415926535, true)]
    [DataRow(int.MinValue, true)]
    [DataRow(int.MaxValue, true)]
    [DataRow(long.MinValue, true)]
    [DataRow(long.MaxValue, true)]
    [DataRow(double.MinValue, false)]
    [DataRow(double.MaxValue, false)]
    public void IsDecimal_FromDataRowTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsDecimal(x);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(null, false)]
    [DataRow("test", false)]
    [DataRow(3.1415926535, true)]
    [DataRow(int.MinValue, true)]
    [DataRow(int.MaxValue, true)]
    [DataRow(long.MinValue, true)]
    [DataRow(long.MaxValue, true)]
    [DataRow(double.MinValue, true)]
    [DataRow(double.MaxValue, true)]
    public void IsDouble_FromDataRowTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsDouble(x);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(null, false)]
    [DataRow("test", false)]
    [DataRow("a5c4c4cb-67f8-407d-8fa7-f59372e5b820", true)]
    public void IsGuid_FromDataRowTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsGuid(x);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(null, false)]
    [DataRow("test", false)]
    [DataRow(3.1415926535, false)]
    [DataRow(int.MinValue, true)]
    [DataRow(int.MaxValue, true)]
    [DataRow(long.MinValue, false)]
    [DataRow(long.MaxValue, false)]
    [DataRow(double.MinValue, false)]
    [DataRow(double.MaxValue, false)]
    public void IsInteger_FromDataRowTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsInteger(x);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(1, 10, 12, false)]
    [DataRow(10, 100, 120, false)]
    [DataRow(-200, 200, -300, false)]
    [DataRow(300, 200, 100, false)]
    [DataRow(1, 10, 5, true)]
    [DataRow(10, 100, 50, true)]
    [DataRow(-200, 200, 100, true)]    
    public void IsInRange_Integer_FromDataRowTest(int x, int y, int z, bool expected)
    {
        var actual = ValidationHelper.IsInRange(x, y, z);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(1.5, 2.5, 1.0, false)]
    [DataRow(100.25, 200.50, 50.50, false)]
    [DataRow(3000, 1000, 2000, false)]
    [DataRow(1.5, 2.5, 2.0, true)]
    [DataRow(100.25, 200.50, 200.25, true)]
    [DataRow(-1000.50, 2000.50, 1000, true)]
    [DataRow(-1000.50, 2000.50, -1000, true)]    
    public void IsInRange_Double_FromDataRowTest(double x, double y, double z, bool expected)
    {
        var actual = ValidationHelper.IsInRange(x, y, z);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetInRangeDecimalTestData =>
        new[] {
                new object[] { 1.5m, 2.5m, 1m, false },
                new object[] { 100.25m, 200.50m, 50.50m, false },
                new object[] { 1.5m, 2.5m, 2m, true },
                new object[] { 100.25m, 200.50m, 200.25m, true },
                new object[] { -1000.50m, 2000.50m, 1000m, true },
                new object[] { decimal.MinValue, decimal.MaxValue, 100m, true },
        };

    [DataTestMethod]
    [DynamicData(nameof(GetInRangeDecimalTestData))]
    public void IsInRange_Decimal_FromDynamicDataTest(decimal x, decimal y, decimal z, bool expected)
    {
        var actual = ValidationHelper.IsInRange(x, y, z);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(null, false)]
    [DataRow("test", false)]
    [DataRow(3.1415926535, false)]
    [DataRow(int.MinValue, true)]
    [DataRow(int.MaxValue, true)]
    [DataRow(long.MinValue, true)]
    [DataRow(long.MaxValue, true)]
    [DataRow(double.MinValue, false)]
    [DataRow(double.MaxValue, false)]
    public void IsLong_FromDataRowTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsLong(x);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow("test", false)]
    [DataRow("null", false)]
    [DataRow("", false)]
    [DataRow(null, true)]
    public void IsNull_FromDataRowTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsNull(x);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(null, false)]
    [DataRow("test", false)]
    [DataRow(-1, false)]
    [DataRow(0, true)]
    [DataRow(1, true)]
    [DataRow(10, true)]
    [DataRow(100, true)]
    public void IsPositive_FromDataRowTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsPositiveNumber(x);
        Assert.AreEqual(expected, actual);
    }
}
