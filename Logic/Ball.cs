using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Ball
    {
        private double _x;
        private double _y;

        public Ball(double x = 0, double y = 0)
        {
            _x = x;
            _y = y;
        }

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
    }
}
