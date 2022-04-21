using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.LogicTests
{
    [TestClass]
    public class BallFactoryTest
    {
        [TestMethod]
        public void createBallsTest()
        {
            List<Ball> balls = BallFactory.CreateBalls(2);
            Assert.AreEqual(2, balls.Count);
        }
    }
}