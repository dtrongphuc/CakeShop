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
        private string sql;
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
        public string ImageUri
        {
            get { return _imageUri; }
            set
            {
                _imageUri = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageUri"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Image()
        {
            this.ImageUri = " ";
            this.IdProduct = " ";
        }

        public void Add()
        {
            sql = "SELECT IDENT_CURRENT('PRODUCT') as LastID";
            _idProduct=Connection.GetCount_Data(sql).ToString();
            sql = $"INSERT INTO IMAGES VALUES ({_idProduct}, '{_imageUri}')";
            Connection.Execute_SQL(sql);
        }
    }
}
