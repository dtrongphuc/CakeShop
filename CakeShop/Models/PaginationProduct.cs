﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    class Pagination : INotifyPropertyChanged
    {
        private string sql;
        private int record1pageProduct = 6;//số lượng phần tử cho 1 trang sản phẩm (home)
        private int record1pageOrder = 5; // số lượng phần tử cho 1 trang đơn hàng
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

       
        
        private int _totalPage = 0;
        public int ToltalPage
        {
            get { return _totalPage; }
            set
            {
                _totalPage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TotalPage"));
            }
        }

        private BindableCollection<Product> _listProduct = new BindableCollection<Product>();

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

        private BindableCollection<Order> _listOrder = new BindableCollection<Order>();

        public BindableCollection<Order> ListOrder
        {
            get { return _listOrder; }
            set
            {
                _listOrder = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListOrder"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Pagination()
        {
            Sum_record = 0;
            CurrentPage = 1;
            //ListProduct = new BindableCollection<Product>();
        }

        public BindableCollection<Product> GetProductPagination(int _curr)
        {
            CurrentPage = _curr;
            Sum_record = GetListObject.Get_CountALLProduct();
            CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * record1pageProduct;
            return Get_AllProduct(sotranghienhanh, record1pageProduct);
        }

        public BindableCollection<Product> GetProductInCategoryPagination(int _curr, string id)
        {
            CurrentPage = _curr;
            sql = $"SELECT COUNT(*) AS [SOLUONG] FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY WHERE CATE.IDCATEGORY={id}";
            Sum_record = Connection.GetCount_Data(sql);
            CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * record1pageProduct;
            ListProduct = Get_ProductInCategory(id,sotranghienhanh, record1pageProduct);
            return ListProduct;
        }

        public BindableCollection<Order> GetOrderPagination(int _curr)
        {
            CurrentPage = _curr;
            Sum_record = GetListObject.Get_CountALLOrder();
            CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * record1pageOrder;
            return Get_AllOrder(sotranghienhanh, record1pageOrder);
        }

        public BindableCollection<Product> Get_AllProduct(int curr, int record1page)
        {
            ListProduct.Clear();
            sql = $"SELECT CATE.CATEGORYNAME,P.* FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY ORDER BY IDPRODUCT OFFSET  { curr}  ROWS FETCH NEXT  { record1page} ROWS ONLY";
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

        public BindableCollection<Product> Get_ProductInCategory(string id, int curr, int record1page)
        {
            ListProduct.Clear();
            sql = $"SELECT CATE.CATEGORYNAME,P.* FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY WHERE CATE.IDCATEGORY={id} ORDER BY IDPRODUCT OFFSET  { curr}  ROWS FETCH NEXT  { record1page} ROWS ONLY";
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

        public BindableCollection<Order> Get_AllOrder(int curr, int record1page)
        {
            ListOrder.Clear();

            sql = $"SELECT * FROM ORDERS ORDER BY IDORDER OFFSET  { curr} ROWS FETCH NEXT  { record1page} ROWS ONLY";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                Order order = new Order();
                order.IdOrder = row["IDORDER"].ToString();
                order.CustomerName = row["CUSTOMERNAME"].ToString();
                order.Address = row["ADDRESS"].ToString();
                order.Email = row["EMAIL"].ToString();
                order.Note = row["NOTE"].ToString();
                order.Total = row["TOTAL"].ToString();
                order.Status = row["STATUS"].ToString();
                order.Date = row["DATE"].ToString();
                ListOrder.Add(order);
            }
            return ListOrder;
        }
        public void CalculateTotalPage()
        {
            double num = (1.0 * Sum_record / record1pageProduct);
            double ToltalPageTemp = Math.Ceiling(num); // Tính tổng số trang và làm tròn lên
            ToltalPage = (int)ToltalPageTemp;
        }
        public List<int> GetPaginaitonNumbers()
        {
            List<int> Numbers = new List<int>();
            int j = 2;
            if (ToltalPage - CurrentPage < 2)
            {
                j = 5 - (ToltalPage - CurrentPage) - 1;
            }
            for (int i = j; i > 0; --i)
            {
                if (CurrentPage > i)
                {
                    Numbers.Add(CurrentPage - i);
                }
            }
            j = (ToltalPage >= 5) ? 5 - Numbers.Count : ToltalPage - Numbers.Count;
            if (ToltalPage - CurrentPage <= 2)
            {
                j = (ToltalPage - CurrentPage) + 1;
            }
            for (int i = 0; i < j; ++i)
            {
                if (CurrentPage <= ToltalPage)
                {
                    Numbers.Add(CurrentPage + i);
                }
            }
            return Numbers;
        }
    }
}
