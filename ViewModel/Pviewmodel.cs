using Model;
using Logic;

namespace ViewModel
{
    public class Pviewmodel

    {
       

        public Pviewmodel()
        {
            
        }

        int radius = 5;
        Movement movement = new Movement(BallFactory.CreateBalls(5, 200, 100));

        public void HandleStartBalls()
        {
            movement.StartMoving();
        }
        
        
    }
}