using System.Collections;
using System.Collections.ObjectModel;
using Logic;
namespace Model
{
    public abstract class Pmodel
    {
        public abstract List<Ball> Balls(int ballNumber, int rectWidth, int rectHeight);
        public abstract void StartAnimation(IList balls); //ruch

        public abstract void StopAnimation();   //zatrzymanie

        public static Pmodel CreateApi()
        {
            return new ModelAPI();
        }

    }
    internal class ModelAPI : Pmodel
    {

        
        public override List<Ball> Balls(int ballNumber, int rectWidth, int rectHeight)
        => BallFactory.CreateBalls(ballNumber,rectWidth,rectHeight);

        private readonly Movement movement;
        public override void StartAnimation(IList balls)
        => movement.StartMoving();

        public override void StopAnimation() => movement.StopMoving();
}
}