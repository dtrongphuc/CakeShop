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
        public string Note { get; set; }
        public string PriceTotal { get; set; }
        public BindableCollection<ItemOrder> OrdersDataGrid { get; set; }
        public DetailOrderViewModel(Order order)
        {
            Custemer = order.CustomerName;
            CreateOnDate = order.Date;
            Address = order.Address;
            Email = order.Email;

            if (order.Note == string.Empty) 
                Note = "Không có mô tả.";
            else Note = order.Note;

            if (order.Status == "1")            
                Delivery = "Đã giao hàng";            
            else Delivery = "Chưa giao hàng";
            //gọi hàm find để tìm ra detail order tương ứng
            detailOrder.Find(order.IdOrder);
            OrdersDataGrid = detailOrder.ListProduct; // trong detail order có 1 list chứa thông tin sản phẩm người dùng mua
            PriceTotal = SumOfMoney(OrdersDataGrid);
        }

        public string SumOfMoney(BindableCollection<ItemOrder> ProductList)
        {
            int Sum = 0;
            foreach(var item in ProductList)
            {
                Sum += int.Parse(item.PriceTotal);
            }
            string Result = Sum.ToString();
            return Result;
        }

    }
}
