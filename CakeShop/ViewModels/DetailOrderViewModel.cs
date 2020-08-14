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
        public BindableCollection<ItemOrder> OrdersDataGrid { get; set; }
        public DetailOrderViewModel(Order order)
        {
            Custemer = order.CustomerName;
            CreateOnDate = order.Date;
            Address = order.Address;
            if (order.Status == "1")
            {
                Delivery = "Đã giao hàng";
            }
            else Delivery = "Chưa giao hàng";
            //gọi hàm find để tìm ra detail order tương ứng
            detailOrder.Find(order.IdOrder);
            OrdersDataGrid = detailOrder.ListProduct; // trong detail order có 1 list chứa thông tin sản phẩm người dùng mua

        }
    }
}
