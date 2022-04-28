using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ViewModelBase
    {
        public RelayCommand RelayCommand { get; set; }
        public ViewModelBase()
        {
            this.RelayCommand = new RelayCommand(this);
        }
        public void ShowBalls()
        {
            Console.WriteLine("Hello World");

        }
    }

}
