using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class Board : INotifyPropertyChanged
    {
        private bool moved = false;
        private readonly Ball ball;
        private double velocityX;
        private double velocityY;
        private double positionX;
        private double positionY;
        private double radius;
        private bool active;
        public event PropertyChangedEventHandler PropertyChanged;


        public Board(Ball b, double vx, double vy, bool active = true)
        {
            b.PropertyChanged += OnPropertyChanged;
            ball = b;
            this.active = active;
            positionX = b.PositionX;
            positionY = b.PositionY;
            radius = b.Radius;

            velocityX = vx;
            velocityY = vy;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Ball b = (Ball)sender;
            switch (e.PropertyName)
            {
                case "PositionX":
                    PositionX = b.PositionX;
                    break;
                case "PositionY":
                    PositionY = b.PositionY;
                    break;
            }
        }
        public bool Moved
        {
            get => moved;
            set => moved = value;
        }
        
        public double PositionX
        {
            get => positionX;
            set
            {
                positionX = value;
                RaisePropertyChanged();
            }
        }
        
        public double PositionY
        {
            get => positionY;
            set
            {
                positionY = value;
                RaisePropertyChanged();
            }
        }
        public double Mass { get => ball.Mass; }

        public double Radius { get => radius; }
        public double VelocityX
        {
            get => velocityX;
            set => velocityX = value;
        }

        public double VelocityY
        {
            get => velocityY;
            set => velocityY = value;
        }

       
        public bool Active { get => active; }
        public void update()
        {
            ball.updateBall(velocityX, velocityY);
        }

        public void start()
        {
            active = true;
        }

        public void stop()
        {
            active = false;
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
