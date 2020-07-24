using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class GetListObject : INotifyPropertyChanged
    {
        private string sql;
        private BindableCollection<Product> _listAllProduct { get; set; } = new BindableCollection<Product>();
        public BindableCollection<Product> ListAllProduct
        {
            get
            {
                return _listAllProduct;
            }
            set
            {
                _listAllProduct = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListAllProduct"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
