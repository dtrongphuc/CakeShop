using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    class PaginationOrder: INotifyPropertyChanged
    {
        private string sql;
        private int _record1page = 5;
        public static int Sum_record { get; set; }
        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        private int _totalPage = 0;
        public int ToltalPage
        {
            get { return _totalPage; }
            set
            {
                _totalPage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TotalPage"));
            }
        }

        private BindableCollection<Order> _listOrder = new BindableCollection<Order>();

        public event PropertyChangedEventHandler PropertyChanged;

        public BindableCollection<Order> ListOrder
        {
            get { return _listOrder; }
            set
            {
                _listOrder = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListOrder"));
            }
        }

        public PaginationOrder()
        {
            Sum_record = 0;
            CurrentPage = 1;
            //ListProduct = new BindableCollection<Product>();
        }


    }
}
