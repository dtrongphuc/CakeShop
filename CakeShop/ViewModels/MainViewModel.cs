﻿using CakeShop.Models;
using CakeShop.Views;
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
        /// <summary>
        /// Khởi tạo
        /// </summary>
        public MainViewModel()
        {
            ShowHome();
        }

        /// <summary>
        /// Mở màn hình trang chủ
        /// </summary>
        public void ShowHome()
        {
            ActivateItem(new HomeViewModel());
            DisplayName = "Trang chủ";
        }

        /// <summary>
        /// Mở màn hình thêm sản phẩm
        /// </summary>
        public void AddProuct()
        {
            CloseCurrentView();
            ActivateItem(new CreatProductViewModel());
            DisplayName = "Thêm sản phẩm";
        }

        /// <summary>
        /// Mở màn hình đơn hàng
        /// </summary>
        public void ShowOrder()
        {
            CloseCurrentView();
            ActivateItem(new OrderProductsViewModel());
            DisplayName = "Đơn đặt hàng";
        }

        public void ShowStatistics()
        {
            CloseCurrentView();
            ActivateItem(new StatisticsViewModel());
            DisplayName = "Thống kê doanh thu";
        }

        /// <summary>
        /// Mở màn hình thêm đơn hàng
        /// </summary>
        public void ShowAddorder()
        {
            CloseCurrentView();
            ActivateItem(new AddOrderViewModel());
            DisplayName = "Thêm đơn hàng";
        }

        /// <summary>
        ///Mở màn hình tìm kiếm 
        /// </summary>
        public void ShowSearch(string key)
        {
            CloseCurrentView();
            ActivateItem(new SearchViewModel(key));
            DisplayName = "Tìm kiếm sản phẩm";
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
