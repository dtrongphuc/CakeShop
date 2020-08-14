using CakeShop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
    public class DetailOrderViewModel : Screen
    {
        DetailOrder detailOrder = new DetailOrder();
        public string Custemer { get; set; }
        public string CreateOnDate { get; set; }
        public string Address { get; set; }
        public string Delivery { get; set; }
        public string Email { get; set; }
        public BindableCollection<DetailOrder> OrdersDataGrid { get; set; }
        public DetailOrderViewModel(Order order)
        {
            Custemer = order.CustomerName;
            CreateOnDate = order.Date;
            Address = order.Address;
            Email = order.Email;
            if (order.Status == "1")
            {
                Delivery = "Đã giao hàng";
            }
            else Delivery = "Chưa giao hàng";

            detailOrder.Find(order.IdOrder);

        }

        //public void BindingDatagrid(Order order)
        //{
        //    var temp = detailOrder.Find(order.IdOrder);
        //    var trara = detailOrder.ListProduct();
        //}
    }
}
