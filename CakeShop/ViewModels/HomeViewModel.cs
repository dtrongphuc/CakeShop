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
        GetListObject Getlist = new GetListObject();
        PaginationProduct  PagProduct = new PaginationProduct();
        public BindableCollection<Product> Products { get; set; }
        public BindableCollection<Category> CatogoryCombobox { get; set; }

        public HomeViewModel()
        {
            //danh mục
            CatogoryCombobox = Getlist.Get_AllCategory();
            //danh sách sản phẩm
            Products = PagProduct.GetProductPagination(1);
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
