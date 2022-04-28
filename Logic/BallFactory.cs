using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BallFactory
    {
        public static List<Ball> CreateBalls(int num, int rectWidth, int rectHeight)
        {
            Random random = new Random();
            List<Ball> list = new List<Ball>();

            for (int i = 0; i < num; i++)
            {
                int randomX = random.Next(rectWidth);
                int randomY = random.Next(rectHeight);

                Ball ball = new Ball(randomX, randomY);
                list.Add(ball);
            }

            return list;
        }
    }
}
