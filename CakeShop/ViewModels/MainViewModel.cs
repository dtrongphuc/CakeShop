using CakeShop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive, INotifyPropertyChanged
    {
        //private HomeViewModel _homeViewModel;
        //public HomeViewModel HomeViewModel
        //{
        //    get { return _homeViewModel; }
        //    set
        //    {
        //        _homeViewModel = value;
        //        NotifyOfPropertyChange(() => HomeViewModel);
        //    }
        //}

        //private OrderProductsViewModel _orderProductsViewModel;
        //public OrderProductsViewModel OrderProductsViewModel
        //{
        //    get { return _orderProductsViewModel; }
        //    set
        //    {
        //        _orderProductsViewModel = value;
        //        NotifyOfPropertyChange(() => OrderProductsViewModel);
        //    }
        //}
        
        /// <summary>
        /// Khởi tạo
        /// </summary>
        public MainViewModel()
        {
            DisplayName = "Trang chủ";
            ActivateItem(new HomeViewModel());
        }
        public void AddProuct()
        {
            CloseCurrentView();
            ActivateItem(new CreatProductViewModel());
            DisplayName = "Thêm sản phẩm";
        }
        public void ShowOrder()
        {
            CloseCurrentView();
            ActivateItem(new OrderProductsViewModel());
            DisplayName = "Đơn đặt hàng";
        }

        /// <summary>
        /// Đóng view hiện tại
        /// </summary>
        public void CloseCurrentView()
        {
            while (Items.Count > 0)
            {
                DeactivateItem(Items[0], true);
            }
        }
    }
}
