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
        private string _IDCategory;
        public string IDCategory
        {
            get { return _IDCategory; }
            set
            {
                _IDCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IDCategory"));
            }
        }

        private string _IDProduct;
            public string IDProduct
        {
            get { return _IDProduct; }
            set
            {
                _IDProduct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IDProduct"));
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
            this.IDCategory = " ";
            this.IDProduct = " ";
            this.ProDuctName = " ";
            this.Image = " ";
            this.Description = " ";
            this.Price = "";
            this.Quantity = " ";
        }

    }
}
