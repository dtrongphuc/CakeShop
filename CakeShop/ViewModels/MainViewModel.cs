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
        private HomeViewModel _homeViewModel;
        public HomeViewModel HomeViewModel
        {
            get { return _homeViewModel; }
            set
            {
                _homeViewModel = value;
                NotifyOfPropertyChange(() => HomeViewModel);
            }
        }

        /// <summary>
        /// Khởi tạo
        /// </summary>
        public MainViewModel()
        {
            DisplayName = "Trang chủ";
            ActivateItem(new HomeViewModel());
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
