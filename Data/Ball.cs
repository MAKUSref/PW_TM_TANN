using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        private double positionX;
        private double positionY;
        private readonly double radius;
        private double mass = 5;

        public Ball(double positionX, double positionY, double radius)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.radius = radius;
        }

        public double Mass { get { return mass; } }

        public double PositionX 
        {            
            get { return positionX; } 
            set 
            { 
                positionX = value;
                RaisePropertyChanged();
            }
        }

        public double PositionY
        {
            get { return positionY; }
            set
            {
                positionY = value;
                RaisePropertyChanged();
            }
        }

        public double Radius { get { return radius; } }

        public void updateBall(double velocityX, double velocityY)
        {
            PositionX += velocityX;
            positionY += velocityY;
        }

        // Property change
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}