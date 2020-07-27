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
    class PaginationProduct : INotifyPropertyChanged
    {
        private string sql;
        public static int Sum_record { get; set; }
        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        private int _record1page = 8;
        public int record1page
        {
            get { return _record1page; }
            set
            {
                _record1page = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("recod1page"));
            }
        }

        private int _totalpage = 0;
        public int ToltalPage
        {
            get { return _totalpage; }
            set
            {
                _totalpage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TotalPage"));
            }
        }

        private BindableCollection<Product> _listProduct;

        public BindableCollection<Product> ListProduct
        {
            get { return _listProduct; }
            set
            {
                _listProduct = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListProduct"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PaginationProduct()
        {
            Sum_record = 0;
            CurrentPage = 1;
            ListProduct = new BindableCollection<Product>();
        }

        GetListObject GetCtrl = new GetListObject();
        public BindableCollection<Product> GetProductPagination(int _curr)
        {
            CurrentPage = _curr;
            Sum_record = GetListObject.Get_CountALLProduct();
            //CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * record1page;
            ListProduct = Get_AllProduct(sotranghienhanh, record1page);
            return ListProduct;
        }

        public BindableCollection<Product> GetProductInCategoryPagination(int _curr, string id)
        {
            CurrentPage = _curr;
            sql = $"SELECT COUNT(*) AS [SOLUONG] FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY WHERE CATE.IDCATEGORY={id}";
            Sum_record = Connection.GetCount_Data(sql);
            //CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * record1page;
            ListProduct = Get_ProductInCategory(id,sotranghienhanh, record1page);
            return ListProduct;
        }

        public BindableCollection<Product> Get_AllProduct(int curr, int recode1trang)
        {
            ListProduct.Clear();
            sql = $"SELECT CATE.CATEGORYNAME,P.* FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY ORDER BY IDPRODUCT OFFSET  { curr}  ROWS FETCH NEXT  { recode1trang} ROWS ONLY";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                Product product = new Product();
                product.CategoryName = row["CATEGORYNAME"].ToString();
                product.IdProduct = row["IDPRODUCT"].ToString();
                product.ProductName = row["PRODUCTNAME"].ToString();
                product.Price = row["PRICE"].ToString();
                product.Description = row["DESCRIPTION"].ToString();
                product.Image = row["IMAGE"].ToString();
                ListProduct.Add(product);
            }
            return ListProduct;
        }

        public BindableCollection<Product> Get_ProductInCategory(string id, int curr, int recode1trang)
        {
            ListProduct.Clear();
            sql = $"SELECT CATE.CATEGORYNAME,P.* FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY WHERE CATE.IDCATEGORY={id} ORDER BY IDPRODUCT OFFSET  { curr}  ROWS FETCH NEXT  { recode1trang} ROWS ONLY";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                Product product = new Product();
                product.CategoryName = row["CATEGORYNAME"].ToString();
                product.IdProduct = row["IDPRODUCT"].ToString();
                product.ProductName = row["PRODUCTNAME"].ToString();
                product.Price = row["PRICE"].ToString();
                product.Description = row["DESCRIPTION"].ToString();
                product.Image = row["IMAGE"].ToString();
                ListProduct.Add(product);
            }
            return ListProduct;
        }
    }
}
