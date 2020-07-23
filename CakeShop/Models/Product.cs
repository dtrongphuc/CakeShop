using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    class Product: INotifyPropertyChanged
    {
        private string _IdCategory;
        public string IdCategory
        {
            get { return _IdCategory; }
            set
            {
                _IdCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdCategory"));
            }
        }

        private string _IdProduct;
            public string IdProduct
        {
            get { return _IdProduct; }
            set
            {
                _IdProduct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdProduct"));
            }
        }

        private string _ProDuctName;
        public string ProDuctName
        {
            get { return _ProDuctName; }
            set
            {
                _ProDuctName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProDuctName"));
            }
        }

        private string _Price;
        public string Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        private string _Image;
        public string Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Image"));
            }
        }

        private string _Quantity;
        public string Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Quantity"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

       
       public Product()
        {
            this.IdCategory = " ";
            this.IdProduct = " ";
            this.ProDuctName = " ";
            this.Image = " ";
            this.Description = " ";
            this.Price = "";
            this.Quantity = " ";
        }

    }
}
