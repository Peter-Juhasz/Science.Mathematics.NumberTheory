using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Science.Mathematics.NumberTheory.Tests
{
    [TestClass]
    public class IntegerExtensionsTests
    {
        [TestMethod]
        [DataRow(1, true)]
        [DataRow(2, true)]
        [DataRow(10, true)]
        [DataRow(0, false)]
        [DataRow(-1, false)]
        [DataRow(-10, false)]
        public void IsPositive(int n, bool result)
        {
            Assert.AreEqual(result, n.IsPositive());
        }

        [TestMethod]
        [DataRow(1, false)]
        [DataRow(2, false)]
        [DataRow(10, false)]
        [DataRow(0, false)]
        [DataRow(-1, true)]
        [DataRow(-10, true)]
        public void IsNegative(int n, bool result)
        {
            Assert.AreEqual(result, n.IsNegative());
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        [DataRow(3, false)]
        [DataRow(9, true)]
        [DataRow(16, true)]
        public void IsPerfectSquare(int n, bool result)
        {
            Assert.AreEqual(result, n.IsPerfectSquare());
        }

        [TestMethod]
        [DataRow(3, 0, 1)]
        [DataRow(5, 1, 5)]
        [DataRow(2, 3, 8)]
        [DataRow(7, 2, 49)]
        public void ToPowerOf(int n, int power, int result)
        {
            Assert.AreEqual(result, n.ToPowerOf(power));
        }
    }
}
