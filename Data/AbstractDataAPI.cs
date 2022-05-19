using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class AbstractDataAPI
    {
        private readonly Container container;

        public AbstractDataAPI(double width, double height)
        {
            container = new Container(width, height);
        }
        
        public Container Container { get { return container; } }

        public abstract Ball createBall();
        public abstract double generateNewPosition(double radius, double currentPosition);

        public static AbstractDataAPI createDataAPI()
        {
            return new DataApi();
        }
    }

    public class DataApi : AbstractDataAPI
    {
        private readonly Random random = new Random();

        public DataApi(double width = 450.0, double height = 300.0) 
            : base(width, height) { }

        public override Ball createBall()
        {
            double radius = 10.0;
            double posX = generateNewPosition(radius, Container.SizeX);
            double posY = generateNewPosition(radius, Container.SizeY);
            bool f = true;

            do
            {
                f = true;

                foreach (Ball b1 in Container.Balls)
                {
                    double dx = posX - b1.PositionX;
                    double dy = posY - b1.PositionY;
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    if (distance <= (radius + b1.Radius))
                    {
                        f = false;
                        posX = generateNewPosition(radius, Container.SizeX);
                        posY = generateNewPosition(radius, Container.SizeY);
                        break;
                    }
                }
            } while (!f);

            Ball b = new Ball(posX, posY, radius);
            
            Container.addBall(b);

            return b;
        }

        public override double generateNewPosition(double radius, double currentPosition)
        {
            return radius + random.NextDouble() * (currentPosition - 2 * radius);
        }
    }
}
