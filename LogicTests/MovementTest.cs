using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Logic;

namespace LogicTests
{
    [TestClass]
    public class MovementTest
    {
        int width, height;
        List<Ball> balls;

        [TestInitialize]
        public void InitTest()
        {
            width = 200;
            height = 100;
            balls = BallFactory.CreateBalls(5, width, height);
        }

        [TestMethod]
        public void movementConstructorTest()
        {
            Movement movement = new Movement(balls);
            Assert.IsNotNull(movement.Balls);
        }
    }
}
