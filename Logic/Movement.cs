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

        public async void StartMoving()
        {
            _ballsMoving = true;

            while (_ballsMoving)
            {
                foreach (Ball ball in _balls)
                {
                    await MoveBall(ball);
                }
            }
        }

        public void StopMoving()
        {
            _ballsMoving = true;
        }

        // private
        private async Task MoveBall(Ball ball)
        {
            if (ball == null) return;

            Thread.Sleep(5);
            double shiftX = await Task.Run(() => GenerateShift());

            Thread.Sleep(5);
            double shiftY = await Task.Run(() => GenerateShift());

            ball.X += shiftX;
            ball.Y += shiftY;
        }

        private double GenerateShift()
        {
            Random random = new Random();
            return random.NextDouble() * (_shiftMax - _shiftMin) + _shiftMin;
        }
    }
}
