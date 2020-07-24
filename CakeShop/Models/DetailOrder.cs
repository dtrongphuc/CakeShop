using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class DetailOrder : INotifyPropertyChanged
    {

        private string _idOrder;
        public string IdOrder
        {
            get { return _idOrder; }
            set
            {
                _idOrder = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdOrder"));
            }
        }

        private string _idProduct;
        public string IdProduct
        {
            get { return _idProduct; }
            set
            {
                _idProduct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdProduct"));
            }
        }

        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Quantity"));
            }
        }

        private string _price;
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }

        private string _priceTotal;
        public string PriceTotal
        {
            get { return _priceTotal; }
            set
            {
                _priceTotal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PriceTotal"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public DetailOrder()
        {
            this.IdOrder = " ";
            this.IdProduct = " ";
            this.Price = " ";
            this.PriceTotal = " ";
            this.Quantity = " ";
        }
    }
}
