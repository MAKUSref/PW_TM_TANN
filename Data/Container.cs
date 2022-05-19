using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Container
    {
        private readonly double sizeX;
        private readonly double sizeY;
        private List<Ball> balls;

        public Container(double sizeX, double sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        public double SizeX { get { return sizeX; } }
        public double SizeY { get { return sizeY; } }
        public List<Ball> Balls { get { return balls; } }

        public void addBall(Ball ball)
        {
            if (ball != null)
            {
                balls.Add(ball);
            }
        }

    }
}
