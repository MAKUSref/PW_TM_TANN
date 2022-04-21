using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BallFactory
    {
        public static List<Ball> CreateBalls(int num, int width, int height)
        {
            Random random = new Random();
            List<Ball> list = new List<Ball>();

            for (int i = 0; i < num; i++)
            {
                int randomX = random.Next(width);
                int randomY = random.Next(height);

                Ball ball = new Ball(randomX, randomY);
                list.Add(ball);
            }

            return list;
        }
    }
}
