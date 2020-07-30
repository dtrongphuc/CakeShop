using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class SizeProduct : INotifyPropertyChanged
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

        private string _size;
        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
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

        public SizeProduct()
        {
            this.IdProduct = " ";
            this.Size = " ";
            this.Quantity = " ";
        }

        public void Add()
        {
            sql = "SELECT IDENT_CURRENT('PRODUCT') as LastID";
            IdProduct=Connection.GetCount_Data(sql).ToString();
            sql = $"INSERT INTO SIZEPRODUCT VALUES ({_idProduct}, '{Size}' , {Quantity})";
            Connection.Execute_SQL(sql);
        }

        public void Update()
        {
            sql = $"UPDATE SIZEPRODUCT SET QUANTITY={Quantity} WHERE IDPRODUCT={IdProduct} AND SIZE=N'{Size}'";
            Connection.Execute_SQL(sql);
        }

       
    }
    
}
