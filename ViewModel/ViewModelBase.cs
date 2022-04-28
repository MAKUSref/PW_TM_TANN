using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Logic;
namespace ViewModel
{
    public class ViewModelBase : ViewModelObservator
    {

        private int _ballsNumber;
        private ModelAPI modelAPI = new ModelAPI();
        private Movement movement;
        private List<Ball> _balls;

        public RelayCommand RelayCommand { get; set; }

        public ViewModelBase()
        {
            this.RelayCommand = new RelayCommand(this);
        }

        private Pmodel model { get; set; }

        public int BallsNumber
        {
            get => _ballsNumber;
            set
            {
                if (value.Equals(_ballsNumber))
                    return;
                if (value < 0)
                    value = 0;
                else if (value > 1000)
                    value = 1000;
                _ballsNumber = value;
                RaisePropertyChanged(nameof(BallsNumber));
            }
        }

        public async void ShowBalls()
        {
            _balls = modelAPI.Balls(_ballsNumber, 800, 100);
            movement = modelAPI.CreateMovement(_balls);
            await modelAPI.StartAnimation(movement, _balls);

        }

        public void StopBalls()
        {
            modelAPI.StopAnimation(movement);

        }


    }

}
