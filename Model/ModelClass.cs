using Logic;
using System.Collections.Generic;

namespace Model
{
    public class ModelClass
    {
        private readonly ILogic _ballsMgr;
        private readonly int _width;
        private readonly int _height;

        public ModelClass(int width, int height)
        {
            _width = width;
            _height = height;
            _ballsMgr = ILogic.Create(width, height);
        }

        public List<IBall2> GetBalls()
        {
            return _ballsMgr.GetAllBalls();
        }

        public void CreateBalls(int amount)
        {
            _ballsMgr.SummonBalls(amount);
        }

        public void ClearBalls()
        {
            _ballsMgr.ClearBalls();
        }



    }
}