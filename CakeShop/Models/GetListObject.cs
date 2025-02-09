﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class GetListObject : INotifyPropertyChanged
    {
        private string sql;
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

        private BindableCollection<Category> _listCategory { get; set; } = new BindableCollection<Category>();
        public BindableCollection<Category> ListCategory
        {
            get
            {
                return _listCategory;
            }
            set
            {
                _listCategory = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListCategory"));
            }
        }

     
        public BindableCollection<SizeProduct> ListSizeProduct { get; set; } = new BindableCollection<SizeProduct>();

        private BindableCollection<Image> _listImageProduct { get; set; } = new BindableCollection<Image>();
        public BindableCollection<Image> ListImageProduct
        {
            get
            {
                return _listImageProduct;
            }
            set
            {
                _listImageProduct = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListImageProduct"));
            }
        }

        private BindableCollection<Order> _listOrder { get; set; } = new BindableCollection<Order>();
        public BindableCollection<Order> ListOrder
        {
            get
            {
                return _listOrder;
            }
            set
            {
                _listOrder = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListOrder"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BindableCollection<Product> Get_AllProduct()
        {
            ListProduct.Clear();
            sql = $"SELECT CATE.CATEGORYNAME,P.* FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY WHERE P.STATUS=0";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
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

        public BindableCollection<Category> Get_AllCategory()
        {
            ListCategory.Clear();
            sql = "SELECT * FROM CATEGORY";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                Category category = new Category();
                category.IdCategory = row["IDCATEGORY"].ToString();
                category.CategoryName = row["CATEGORYNAME"].ToString();
                ListCategory.Add(category);
            }
            return ListCategory;
        }

        public BindableCollection<Product> Get_ProductInCategory(string id)
        {
            ListProduct.Clear();
            sql = $"SELECT CATE.CATEGORYNAME,P.* FROM PRODUCT AS P JOIN CATEGORY AS CATE ON P.IDCATEGORY=CATE.IDCATEGORY WHERE P.IDCATEGORY={id} AND P.STATUS=0";
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

        public BindableCollection<SizeProduct> Get_SizeProduct(string id)
        {
            ListSizeProduct.Clear();
            if (id == string.Empty) return ListSizeProduct;
            sql = $"SELECT * FROM  SIZEPRODUCT WHERE IDPRODUCT={id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                SizeProduct size = new SizeProduct();
                size.IdProduct = row["IDPRODUCT"].ToString();
                size.Size = row["SIZE"].ToString();
                size.Quantity = row["QUANTITY"].ToString();
                ListSizeProduct.Add(size);
            }
            return ListSizeProduct;
        }

        public BindableCollection<Image> Get_ImageProduct(string id)
        {
            ListImageProduct.Clear();
            sql = $"SELECT * FROM IMAGES WHERE IDPRODUCT={id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                Image image = new Image();
                image.IdProduct = row["IDPRODUCT"].ToString();
                image.ImageUri = row["IMAGE"].ToString();
                ListImageProduct.Add(image);
            }
            return ListImageProduct;
        }

         public BindableCollection<Order> Get_AllOrder()
        {
            ListOrder.Clear();
            sql = "SELECT * FROM ORDERS";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
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

        public BindableCollection<Order> Get_MonthlyOrder()
        {
            ListOrder.Clear();
            sql = "SELECT IDORDER, CUSTOMERNAME, ADDRESS, EMAIL, NOTE, TOTAL, STATUS, MONTH(DATE)AS 'MONTH' FROM ORDERS";
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
                order.Date = row["MONTH"].ToString();
                ListOrder.Add(order);
            }
            return ListOrder;
        }

        public static int Get_CountALLProduct()
        {
            string sql = "SELECT COUNT(*) AS [SOLUONG] FROM PRODUCT WHERE STATUS=0";
            int id = Connection.GetCount_Data(sql);
            return id;
        }

        public static int Get_CountALLOrder()
        {
            string sql = "SELECT COUNT(*) AS [SOLUONG] FROM ORDERS";
            int id = Connection.GetCount_Data(sql);
            return id;
        }


        

        public BindableCollection<dynamic> Turnover()
        {
            BindableCollection<dynamic> listTurnover = new BindableCollection<dynamic>();
            sql = "select cate.CATEGORYNAME,temp.Sales from CATEGORY as cate join (select p.IDCATEGORY,sum(totalprice)as 'Sales' from DETAILORDER as dt join PRODUCT as p on p.idproduct=dt.idproduct WHERE P.STATUS=0 group by p.IDCATEGORY) as temp on cate.idcategory=temp.idcategory";

            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                dynamic turnover = new ExpandoObject();
                turnover.CategoryName = row["CATEGORYNAME"].ToString();
                turnover.sales= row["Sales"].ToString();
                listTurnover.Add(turnover);
            }
            return listTurnover;
        }
    }
}
