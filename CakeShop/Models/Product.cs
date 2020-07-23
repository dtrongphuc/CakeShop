using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Product: INotifyPropertyChanged
    {
        private string _idCategory;
        public string IdCategory
        {
            get { return _idCategory; }
            set
            {
                _idCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdCategory"));
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

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductName"));
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Image"));
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

        public event PropertyChangedEventHandler PropertyChanged;

       
        public Product()
        {
            this.IdCategory = " ";
            this.IdProduct = " ";
            this.ProductName = " ";
            this.Image = " ";
            this.Description = " ";
            this.Price = "";
            this.Quantity = " ";
        }
    }
}
