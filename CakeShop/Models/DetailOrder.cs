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

        

        private BindableCollection<ItemOrder> _listProduct { get; set; } = new BindableCollection<ItemOrder>();
        public BindableCollection<ItemOrder> ListProduct
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

      


        
        public event PropertyChangedEventHandler PropertyChanged;

        public DetailOrder()
        {
            this.IdOrder = " ";
           
        }

        public bool Find(string id)
        {
            bool check = false;
            sql = $"SELECT * FROM DETAILORDER WHERE IDORDER={id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                check = true;
                ItemOrder product = new ItemOrder();
                this.IdOrder = row["IDORDER"].ToString();
                var IdProduct = row["IDPRODUCT"].ToString();
                product.Find(IdProduct);
                product.Quantity = row["QUATITY"].ToString();
                product.Size = row["SIZE"].ToString();
                product.PriceTotal = row["TOTALPRICE"].ToString();
                ListProduct.Add(product);
            }
            if (check == true)
                return true;
            return false;
        }

        public void Add()
        {
            sql = "SELECT IDENT_CURRENT('ORDERS') as LastID";
            IdOrder = Connection.GetCount_Data(sql).ToString();
            foreach (ItemOrder product in this.ListProduct)
            {
                sql = $"INSERT INTO DETAILORDER VALUES ({IdOrder}, {product.IdProduct}, {product.Quantity}, '{product.Size}', {product.PriceTotal})";
                Connection.Execute_SQL(sql);
            }
        }
    }
}
