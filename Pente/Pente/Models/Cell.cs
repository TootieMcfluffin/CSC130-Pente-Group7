using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Models
{
    [Serializable]
    public class Cell : INotifyPropertyChanged
    {
        string tokenXY = " ";

        public Cell()
        {

        }

        public Cell(String token)
        {
            this.TokenXY = token;
        }

        public string TokenXY
        {
            get { return tokenXY; }
            set
            {
                tokenXY = value;
                OnPropertyChanged("tokenXY");
            }
        }
        //[Serializable]
        public event PropertyChangedEventHandler PropertyChanged;

        //[Serializable]
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
