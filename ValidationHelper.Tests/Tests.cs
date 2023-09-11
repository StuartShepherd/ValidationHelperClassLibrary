namespace ValidationHelper.Tests;

[TestClass]
public class Tests
{
    [DataTestMethod]
    [DataRow(null, 1, 1)]
    [DataRow(3.14, 1, 1)]
    [DataRow(100, 1, 100)]
    [DataRow("test", 0, 0)]
    [DataRow(int.MinValue, 1, int.MinValue)]
    [DataRow(int.MaxValue, 1, int.MaxValue)]
    public void GetIntegerTest(object x, int y, int expected)
    {
        var actual = ValidationHelper.GetInteger(x, y);
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> GetStringTestData =>
        new[] {
                new object[] { null, "test", "test" },
                new object[] { "test", null, "test" },
                new object[] { int.MinValue, null, Convert.ToString(int.MinValue) },
                new object[] { int.MaxValue, null, Convert.ToString(int.MaxValue) },
                new object[] { long.MinValue, null, Convert.ToString(long.MinValue) },
                new object[] { long.MaxValue, null, Convert.ToString(long.MaxValue) },
                new object[] { decimal.MinValue, null, Convert.ToString(decimal.MinValue) },
                new object[] { decimal.MaxValue, null, Convert.ToString(decimal.MaxValue) },
                new object[] { DateTime.MinValue, null, Convert.ToString(DateTime.MinValue) },
        };

    [TestMethod]
    [DynamicData(nameof(GetStringTestData))]
    public void GetStringTest(object x, string y, string expected)
    {
        var actual = ValidationHelper.GetString(x, y);
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
    public void IsIntegerTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsInteger(x);
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
    public void IsLongTest(object x, bool expected)
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
    public void IsNullTest(object x, bool expected)
    {
        var actual = ValidationHelper.IsNull(x);
        Assert.AreEqual(expected, actual);
    }
}
