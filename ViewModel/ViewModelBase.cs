using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Logic;
namespace ViewModel
{
    public class ViewModelBase
    {
        
        private int _ballsNumber;
        private readonly Pmodel _pmodel;
        private List<Ball> _balls;
        public RelayCommand RelayCommand { get; set; }
        public ViewModelBase()
        {
            this.RelayCommand = new RelayCommand(this);
        }
        private Pmodel model { get; set; }
       
        public void ShowBalls()
        {
            _balls = _pmodel.Balls(_ballsNumber,800,100);
            _pmodel.StartAnimation(_balls);

        }

        public void StopBalls()
        {
            _pmodel.StopAnimation();

        }


    }

}
