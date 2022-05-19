﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class AbstractLogicAPI
    {
        private readonly AbstractDataAPI dataAPI;
        public AbstractLogicAPI(AbstractDataAPI dataAPI = null)
        {
            this.dataAPI = dataAPI ?? AbstractDataAPI.createDataAPI();
        }
        public AbstractDataAPI DataAPI
        {
            get => dataAPI;
        }
        public abstract List<Board> GetBalls();

        public abstract void createBall();
        public abstract void createBalls(int count);
        public abstract void start();
        public abstract void stop();
        public static AbstractLogicAPI createLogicAPI(AbstractDataAPI dataAPI = null)
        {
            return new LogicAPI(dataAPI);
        }
    }
    public class LogicAPI : AbstractLogicAPI
    {
        private readonly Random random = new Random();
        private bool isRunning = false;
        private List<Thread> ballThreads = new List<Thread>();
        private List<Board> balls = new List<Board>();

        private double width;
        private double height;
        public override List<Board> GetBalls() => balls;

        private object _lock = new object();

        private Barrier barrier = new Barrier(0);

        public LogicAPI(AbstractDataAPI abstractDataAPI = null)
            : base(abstractDataAPI)
        {
            width = DataAPI.Container.SizeX;
            height = DataAPI.Container.SizeY;
        }
        public override void createBall()
        {
            Ball b = DataAPI.createBall();
            int angle = random.Next(360);
            double velocityMagnitude = 5;
            double vx = Math.Sin(angle * Math.PI / 180) * velocityMagnitude;
            double vy = Math.Cos(angle * Math.PI / 180) * velocityMagnitude;
            Board bw = new Board(b, vx, vy);
            balls.Add(bw);

            barrier.AddParticipant();

            Thread t = new Thread(() =>
            {
                while (bw.Active)
                {
                    bw.Moved = false;
                    if ((bw.Radius + bw.PositionX) > width)
                    {
                        bw.VelocityX *= -1;
                        bw.PositionX = width - Math.Abs(bw.PositionX - width);
                    }
                    else if (bw.PositionX < bw.Radius)
                    {
                        bw.VelocityX *= -1;
                        bw.PositionX = bw.Radius + Math.Abs(bw.Radius - bw.PositionX);
                    }

                    if ((bw.PositionY + bw.Radius) > height)
                    {
                        bw.VelocityY *= -1;
                        bw.PositionY = height - Math.Abs(bw.PositionY - height);
                    }
                    else if (bw.PositionY < bw.Radius)
                    {
                        bw.VelocityY *= -1;
                        bw.PositionY = bw.Radius + Math.Abs(bw.Radius - bw.PositionY);
                    }

                    Thread.Sleep(10);
                    barrier.SignalAndWait();

                    lock (_lock)
                    {
                        bw.update();
                        if (!bw.Moved)
                        {
                            detectCollisions(bw);
                        }
                    }
                }
            });
            if (isRunning)
            {
                t.Start();
            }
            ballThreads.Add(t);
        }
        private void detectCollisions(Board ball)
        {
            double px = ball.PositionX;
            double py = ball.PositionY;
            foreach (Board b in balls)
            {
                if (b == ball) continue;

                if (b.Moved) continue;

                double dx = px - b.PositionX;
                double dy = py - b.PositionY;
                double massDifference = ball.Mass - b.Mass;
                double massSum = ball.Mass + b.Mass;

                if (Math.Sqrt(dx * dx + dy * dy) <= (ball.Radius + b.Radius))
                {
                    double v1x = ball.VelocityX, v1y = ball.VelocityY, v2x = b.VelocityX, v2y = b.VelocityY;

                    ball.VelocityX = (v1x * massDifference + 2 * b.Mass * v2x) / massSum;
                    ball.VelocityY = (v1y * massDifference + 2 * b.Mass * v2y) / massSum;

                    b.VelocityX = (-v2x * massDifference + 2 * ball.Mass * v1x) / massSum;
                    b.VelocityY = (-v2y * massDifference + 2 * ball.Mass * v2y) / massSum;

                    ball.Moved = true;
                    b.Moved = true;
                }
            }
        }
        public override void createBalls(int count)
        {
            for (int i = 0; i < count; i++)
            {
                createBall();
            }
        }
        public override void start()
        {
            if (!isRunning)
            {
                isRunning = true;
                foreach (Thread thread in ballThreads)
                {
                    thread.Start();
                }
            }
        }
        public override void stop()
        {
            isRunning = false;
        }
        ~LogicAPI()
        {
            isRunning = false;
            foreach (Board bw in balls)
            {
                bw.stop();
            }
        }
    }
}
