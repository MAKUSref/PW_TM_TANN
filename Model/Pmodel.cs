using System.Collections;
using System.Collections.ObjectModel;
using Logic;
namespace Model
{
    public abstract class Pmodel
    {

        public abstract List<Ball> Balls(int ballNumber, int rectWidth, int rectHeight);

        public abstract Movement CreateMovement(List<Ball> balls);
        

        public abstract void StopAnimation(Movement instance);   //zatrzymanie

        public static Pmodel CreateApi()
        {
            return new ModelAPI();
        }

    }
    public class ModelAPI : Pmodel
    {
        public override List<Ball> Balls(int ballNumber, int rectWidth, int rectHeight)
        => BallFactory.CreateBalls(ballNumber, rectWidth, rectHeight);

        public override Movement CreateMovement(List<Ball> balls) => new Movement(balls);


       

        public override void StopAnimation(Movement instance) => instance.StopMoving();
    }
}