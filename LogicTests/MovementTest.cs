using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using Logic;

namespace LogicTests
{
    /*
    [TestClass]
    public class MovementTest
    {
        int width, height;
        int ballsNumber = 5;
        List<Ball> balls;
        Movement movement;

        [TestInitialize]
        public void InitTest()
        {
            width = 200;
            height = 100;
            balls = BallFactory.CreateBalls(ballsNumber, width, height);
            movement = new Movement(balls);
        }

        [TestMethod]
        public void movementConstructorTest()
        {
            Assert.AreEqual(movement.Balls.Count, ballsNumber);
        }

        public void startMovingTest()
        {
            double firstX = movement.Balls[0].X;
            double firstY = movement.Balls[0].Y;

            double secondX = movement.Balls[1].X;
            double secondY = movement.Balls[1].Y;

            movement.StartMoving();
            Thread.Sleep(200);

            movement.StopMoving();

            double firstXAfterMove = movement.Balls[0].X;
            double firstYAfterMove = movement.Balls[0].Y;

            double secondXAfterMove = movement.Balls[1].X;
            double secondYAfterMove = movement.Balls[1].Y;

            Assert.AreNotEqual(firstX, firstXAfterMove);
            Assert.AreNotEqual(firstY, firstYAfterMove);

            Assert.AreNotEqual(secondX, secondXAfterMove);
            Assert.AreNotEqual(secondY, secondYAfterMove);
        }
    */
    }
}
