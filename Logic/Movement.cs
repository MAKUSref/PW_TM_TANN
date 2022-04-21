using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Movement
    {
        private readonly double _shiftMin;
        private readonly double _shiftMax;
        private List<Ball> _balls;
        private bool _ballsMoving = false;

        public Movement(List<Ball> balls, double shiftMin = -1, double shiftMax = 1)
        {
            _shiftMin = shiftMin;
            _shiftMax = shiftMax;
            _balls = balls;
        }

        public List<Ball> Balls { get => _balls; }

        public void StartMoving()
        {
            _ballsMoving = true;

            while (_ballsMoving)
            {
                foreach (Ball ball in _balls)
                {
                    MoveBall(ball);
                }
            }
        }

        public void stopMoving()
        {
            _ballsMoving = true;
        }

        // private
        private double GenerateShift()
        {
            Random random = new Random();
            return random.NextDouble() * (_shiftMax - _shiftMin) + _shiftMin;
        }

        private void MoveBall(Ball ball)
        {
            if (ball == null) return;

            double shiftX = GenerateShift();
            double shiftY = GenerateShift();

            ball.X += shiftX;
            ball.Y += shiftY;
        }
    }
}
