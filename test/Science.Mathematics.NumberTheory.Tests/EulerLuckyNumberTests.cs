using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Science.Mathematics.NumberTheory.Tests;

[TestClass]
public class EulerLuckyNumberTests
{
    [TestMethod]
    public void Is_41()
    {
        Assert.IsTrue(41.IsEulersLuckyNumber());
    }
}