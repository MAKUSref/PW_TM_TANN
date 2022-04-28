using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace ViewModel
{
    public class ViewModelBase
    {
        private int _ballsNumber;
        private readonly Pmodel _pmodel;

        public RelayCommand RelayCommand { get; set; }
        public ViewModelBase()
        {
            this.RelayCommand = new RelayCommand(this);
        }
        public void ShowBalls()
        {
            Console.WriteLine("Hello World");

        }

        private Pmodel model { get; set; }
        
    }

}
