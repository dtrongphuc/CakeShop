using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Product: INotifyPropertyChanged
    {
        private string sql;
        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CategoryName"));
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

       

        public event PropertyChangedEventHandler PropertyChanged;

       
        public Product()
        {
            this.CategoryName = " ";
            this.IdProduct = " ";
            this.ProductName = " ";
            this.Image = " ";
            this.Description = " ";
            this.Price = "";
            this.IdCategory= " ";
        }

        public bool Find(string id)
        {
            bool check = false;
            string sql = $"SELECT CATE.CATEGORYNAME,P.* FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY WHERE IDPRODUCT={id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                check = true;
                Product product = new Product();
                product.CategoryName = row["CATEGORYNAME"].ToString();
                product.IdProduct = row["IDPRODUCT"].ToString();
                product.ProductName = row["PRODUCTNAME"].ToString();
                product.Price = row["PRICE"].ToString();
                product.Description = row["DESCRIPTION"].ToString();
                product.Image = row["IMAGE"].ToString();
               
            }
            if (check == true)
            {
                return true;
            }
            return false;
        }

        public void Add()
        {
            sql = $"INSERT INTO PRODUCT VALUES ({IdProduct}, {IdCategory}, N'{ProductName}',{Price}, N'{Description}' , '{Image}' )";
            Connection.Execute_SQL(sql);
        }
    }
}
