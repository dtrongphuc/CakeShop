using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeShop.Models;
using System.Windows;

namespace CakeShop.ViewModels
{
    public class HomeViewModel : Screen
    {
        GetListObject Getlist = new GetListObject();
        PaginationProduct PagProduct = new PaginationProduct();
        List<int> PageNumbers;
        
        public BindableCollection<Product> Products { get; set; }
        public BindableCollection<Category> CatogoryCombobox { get; set; }
        public BindableCollection<PaginationStyle> PaginationNumber { get; set; }

        public HomeViewModel()
        {
            //danh mục
            CatogoryCombobox = Getlist.Get_AllCategory();
            //danh sách sản phẩm
            UpdateProductsPagination(1, false, false);

            PaginationNumber = new BindableCollection<PaginationStyle>();
        }

        public void UpdateProductsPagination(int currentPage, bool isPrevClick, bool isNextClick)
        {
            if(isPrevClick)
            {
                if(PagProduct.CurrentPage > 1)
                {
                    PagProduct.CurrentPage--;
                    
                }
            } else if (isNextClick)
            {
                if(PagProduct.CurrentPage < PagProduct.ToltalPage)
                {
                    PagProduct.CurrentPage++;
                }
            }

             if (currentPage == 0)
            {
                PagProduct.CurrentPage = PagProduct.ToltalPage;
            } else if(currentPage != -1)
            {
                PagProduct.CurrentPage = currentPage;
            }

            Products = PagProduct.GetProductPagination(PagProduct.CurrentPage);
            PageNumbers = PagProduct.GetPaginaitonNumbers();
        }

        /// <summary>
        /// Mở trang chi tiết 
        /// </summary>
        /// <param name="productSelected">Sản phẩm được chọn</param>
        public void ShowDetail(Product productSelected)
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailProductViewModel(productSelected.IdProduct));
        }

        public void SetStylePagination(Style defaultStyle, Style selectedStyle)
        {
            PaginationNumber.Clear();
            foreach (var number in PageNumbers)
            {
                Style myStyle = defaultStyle;
                if (number == PagProduct.CurrentPage)
                {
                    myStyle = selectedStyle;
                }
                PaginationNumber.Add(new PaginationStyle() { Number = number, PageBtnStyle = myStyle });
            }
        }
    }
}
