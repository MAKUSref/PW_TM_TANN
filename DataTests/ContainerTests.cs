using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void addBallTest()
        {
            Container container = new Container(100, 100);
            Ball b = new Ball(50, 50, 5);

            Assert.AreEqual(0, container.Balls.Count);

            container.addBall(b);

            Assert.AreEqual(1, container.Balls.Count);
        }
    }
}
