using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Science.Mathematics.NumberTheory.Tests;

[TestClass]
public class DigitsTests
{
    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(2, 1)]
    [DataRow(10, 2)]
    [DataRow(0, 1)]
    [DataRow(-1, 1)]
    [DataRow(-10, 2)]
    [DataRow(-123, 3)]
    public void Length_Base10(int n, int length)
    {
        Assert.AreEqual(length, n.Length());
    }

    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(2, 2)]
    [DataRow(10, 4)]
    [DataRow(0, 1)]
    [DataRow(-1, 1)]
    [DataRow(-10, 4)]
    public void Length_Base2(int n, int length)
    {
        Assert.AreEqual(length, n.Length(2));
    }

    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(2, 1)]
    [DataRow(10, 1)]
    [DataRow(15, 1)]
    [DataRow(16, 2)]
    [DataRow(17, 2)]
    public void Length_Base16(int n, int length)
    {
        Assert.AreEqual(length, n.Length(16));
    }

    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(2, 1)]
    [DataRow(10, 1)]
    [DataRow(16, 1)]
    [DataRow(17, 2)]
    [DataRow(18, 2)]
    public void Length_Base17(int n, int length)
    {
        Assert.AreEqual(length, n.Length(17));
    }

    [TestMethod]
    [DataRow(1, new[] { 1 })]
    [DataRow(10, new[] { 1, 0 })]
    [DataRow(123, new[] { 1, 2, 3 })]
    [DataRow(123456789, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
    [DataRow(-123, new[] { 1, 2, 3 })]
    public void Digits_Base10(int n, int[] digits)
    {
        CollectionAssert.AreEqual(digits, n.Digits(10).ToArray());
    }
}