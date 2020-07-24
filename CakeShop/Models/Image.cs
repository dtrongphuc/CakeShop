using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Image : INotifyPropertyChanged
    {

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

        private string _imageUri;
        public string ImagUri
        {
            get { return _imageUri; }
            set
            {
                _imageUri = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageUri"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
