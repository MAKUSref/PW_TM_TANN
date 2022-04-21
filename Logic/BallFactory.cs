using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BallFactory
    {
        public static List<Ball> CreateBalls(int num)
        {
            List<Ball> list = new List<Ball>();

            for (int i = 0; i < num; i++)
            {
                Ball ball = new Ball();
                list.Add(ball);
            }

            return list;
        }
    }
}
