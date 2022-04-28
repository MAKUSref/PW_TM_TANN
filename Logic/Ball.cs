using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private double _x;
        private double _y;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Ball(double x = 0, double y = 0)
        {
            _x = x;
            _y = y;
        }

        public double X { get => _x; set
            {
                if (value.Equals(_x))
                    return;
                _x = value;
                RaisePropertyChanged(nameof(X));
            }
        }
        public double Y { get => _y; set
            {
                if (value.Equals(_y))
                    return;
                _y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }
    }
}
