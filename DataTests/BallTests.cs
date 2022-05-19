using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTests
{
    [TestClass]
    public class BallTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Ball b = new Ball(0.0, 0.0, 10.0);
            b.updateBall(1.5, -1.0);
            Assert.AreEqual(1.5, b.PositionX);
            Assert.AreEqual(-1.0, b.PositionY);
        }
    }
}