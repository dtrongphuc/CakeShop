using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeShop.Models;

namespace CakeShop.ViewModels
{
    public class HomeViewModel : Screen
    {
        public HomeViewModel()
        {

        }

        /// <summary>
        /// Mở trang chi tiết 
        /// </summary>
        /// <param name="productSelected">Sản phẩm được chọn</param>
        //public void ShowDetail(Product productSelected)
        //{
        //    var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
        //    Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
        //    MainConductor.DeactivateItem(MainConductor.Items[0], true);
        //    parentConductor.ActivateItem(new DetailProductViewModel(productSelected.IdProduct));
        //}

        public void ShowDetail()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailProductViewModel());
        }
    }
}
