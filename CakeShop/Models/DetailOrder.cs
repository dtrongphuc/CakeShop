using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class DetailOrder : INotifyPropertyChanged
    {
        private string sql;
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

        private BindableCollection<Product> _listProduct { get; set; } = new BindableCollection<Product>();
        public BindableCollection<Product> ListProduct
        {
            get
            {
                return _listProduct;
            }
            set
            {
                _listProduct = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListProduct"));
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
            this.PriceTotal = " ";
            this.Quantity = " ";
            this.Size = " ";
        }

        public bool Find(string id)
        {
            bool check = false;
             sql = $"SELECT * FROM DETAILORDER WHERE IDORDER={id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                check = true;
                Product product = new Product();
                this.IdOrder = row["IDORDER"].ToString();
                this.IdProduct = row["IDPRODUCT"].ToString();
                product.Find(IdProduct);
                ListProduct.Add(product);
                this.Quantity = row["QUATITY"].ToString();
                this.Size = row["SIZE"].ToString();
                this.PriceTotal = row["TOTALPRICE"].ToString();
            }
            if (check == true)
                return true;
            return false;
        }

        public void Add()
        {
            sql = "SELECT IDENT_CURRENT('ORDERS') as LastID";
            IdOrder = Connection.GetCount_Data(sql).ToString();
            sql = $"INSERT INTO DETAILORDER VALUES ({IdOrder}, {IdProduct}, {Quantity}, '{Size}', {PriceTotal})";
            Connection.Execute_SQL(sql);
        }
    }
}
