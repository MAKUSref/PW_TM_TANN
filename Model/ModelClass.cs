using Logic;
using System.Collections.Generic;

namespace Model
{
    public class ModelClass
    {
        private readonly ILogic _ballsManager;
        private readonly int _width;
        private readonly int _height;

        public ModelClass(int width, int height)
        {
            _width = width;
            _height = height;
            _ballsManager = ILogic.Create(width, height);
        }

        public List<IBall2> GetBalls()
        {
            return _ballsManager.GetAllBalls();
        }

        public void CreateBalls(int amount)
        {
            _ballsManager.SummonBalls(amount);
        }

        public void ClearBalls()
        {
            _ballsManager.ClearBalls();
        }



    }
}