using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Models
{
    public class Cell : INotifyPropertyChanged
    {
        string tokenXY = " ";

        public string TokenXY
        {
            get { return tokenXY; }
            set
            {
                tokenXY = value;
                OnPropertyChanged("tokenXY");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
