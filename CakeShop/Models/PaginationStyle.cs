using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CakeShop.Models
{
    public class PaginationStyle: INotifyPropertyChanged
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Number"));
            }
        }

        private Style _pagebtnstyle;
        public Style PageBtnStyle
        {
            get { return _pagebtnstyle; }
            set
            {
                _pagebtnstyle = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("PageBtnStyle"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
