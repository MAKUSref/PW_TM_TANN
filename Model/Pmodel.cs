using System.Collections;
using System.Collections.ObjectModel;
using Logic;
namespace Model
{
    public abstract class Pmodel
    {
        public abstract List<Ball> Balls(int ballNumber, int rectWidth, int rectHeight);
        public abstract void Animation(IList balls); //ruch

        public abstract void StopAnimation();   //zatrzymanie
        /*public static Pmodel CreateApi()
        {
            return new ModelAPI();
        }*/


    }
    /*internal class ModelAPI : Pmodel
    {
        private readonly BallFactory factory = new BallFactory();
        public override List<Ball> Balls(int ballNumber, int rectWidth, int rectHeight)
        => factory.CreateBalls(ballNumber,rectWidth,rectHeight);

        public override void Animation(IList balls)
        => factory.Target((ObservableCollection<Ball>)balls);

        public override void StopAnimation() => factory.Exit();
}*/
}