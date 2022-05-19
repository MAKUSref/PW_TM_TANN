using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private int ballCountInt = 2;
        private Pmodel modelAPI = Pmodel.createPmodelAPI();

        public ViewModelBase()
        {
            StartCommand = new RelayCommand(Start);
            AddBallCommand = new RelayCommand(AddBall);
            ClosingCommand = new RelayCommand(Close);
        }

        public ObservableCollection<ModelAdapter> Balls
        {
            get => modelAPI.ObservableBallCollection;
            set
            {
                modelAPI.ObservableBallCollection = value;
            }
        }

        public string BallCount
        {
            get => Convert.ToString(ballCountInt);
            set
            {
                try
                {
                    int ballNum = Convert.ToInt32(value);
                    if (ballNum > 0)
                    {
                        ballCountInt = ballNum;
                    }
                }
                catch (FormatException)
                {
                    ballCountInt = 2;
                }
            }
        }

        public ICommand StartCommand { get; set; }
        public ICommand AddBallCommand { get; set; }
        public ICommand RemoveBallCommand { get; set; }
        public ICommand ClosingCommand { get; set; }

        private void Start(object obj)
        {
            if (modelAPI.ObservableBallCollection.Count == 0)
            {
                modelAPI.createBalls(ballCountInt);
            }
            modelAPI.start();
        }

        private void Close(object obj)
        {
            // TODO bind this method to window closing
            modelAPI.stop();
        }

        private void AddBall(object obj)
        {
            ballCountInt++; ;
            modelAPI.addBall();
            RaisePropertyChanged();
        }

        // Property change
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
