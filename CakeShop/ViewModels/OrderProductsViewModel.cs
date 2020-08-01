using CakeShop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
    public class OrderProductsViewModel : Screen
    {
        public GetListObject GetData = new GetListObject();
        public DetailOrder GetDetail = new DetailOrder();
        public BindableCollection<Order> OrdersDataGrid { get; set; }
        public BindableCollection<Product> DetailDataGrid { get; set; }
        public OrderProductsViewModel() 
        {
            OrdersDataGrid = GetData.Get_AllOrder();
            GetDetail.Find("1");
            DetailDataGrid = GetDetail.ListProduct;
        }
    }
}
