﻿using CakeShop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeShop.Views;
using System.IO;
using System.IO.Packaging;

namespace CakeShop.Views
{
    public class AddOrderViewModel : Screen
    {
        Product product = new Product();
        GetListObject GetList = new GetListObject();
        public string PriceProduct { get; set; }

        //tổng giá 1 sản phẩm 
        public string TotalPriceProductTextbox { get; set; }
        public string TotalPriceProductsTextblock { get; set; }
        public BindableCollection<Product> ProductsNameCombobox { get; set; } 
        int sum;

        public AddOrderViewModel()
        {
            ProductsNameCombobox = GetList.Get_AllProduct();
        }
        public void AddOrder(string name, string email, string address, string des, string date, int status, int sum)
        {
            Order order = new Order();
            order.CustomerName = name;
            order.Email = email;
            order.Address = address;
            order.Note = des;
            order.Date = date;
            order.Status = status.ToString();
            order.Total = sum.ToString();
            order.Add();
        }

        public void AddDetailOrder(List<DetailOrder> list)
        {
            foreach(var detail in list)
            {
                detail.Add();
            }
        }

        //binding gia sản phẩm tương ứng
        public void BindingPriceProduct(string idproduct)
        {
            product.Find(idproduct);
            PriceProduct = product.Price;
        }

        public void AddToListbox(string Productname, string Price, string Size, string Amount)//Productname, Priceproduct, Size, Amount
        { 

            if (Productname != string.Empty && Size != string.Empty)
            {

            }
        }
    }
}
