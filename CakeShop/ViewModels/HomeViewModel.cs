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
        Pagination PagProduct = new Pagination();
        List<int> PageNumbers;
        
        public BindableCollection<Product> Products { get; set; }
        public BindableCollection<Category> CatogoryCombobox { get; set; }
        public BindableCollection<PaginationStyle> PaginationNumber { get; set; }
        public BindableCollection<Category> CategoryCombobox { get; set; } = new BindableCollection<Category>();

        public HomeViewModel()
        {
            string categoryAll = "Tất Cả";
            Category cate = new Category("0",categoryAll);
            //danh mục
            CategoryCombobox = Getlist.Get_AllCategory();
            CategoryCombobox.Insert(0,cate);
            //danh sách sản phẩm
            UpdateProductsPagination(1, false, false, string.Empty);

            PaginationNumber = new BindableCollection<PaginationStyle>();
        }

        public void UpdateProductsPagination(int currentPage, bool isPrevClick, bool isNextClick, string idCategory)
        {
            if (isPrevClick)
            {
                if (PagProduct.CurrentPage > 1)
                {
                    PagProduct.CurrentPage--;

                }
            } else if (isNextClick)
            {
                if (PagProduct.CurrentPage < PagProduct.ToltalPage)
                {
                    PagProduct.CurrentPage++;
                }
            }

            if (currentPage == 0)
            {
                PagProduct.CurrentPage = PagProduct.ToltalPage;
            } else if (currentPage != -1)
            {
                PagProduct.CurrentPage = currentPage;
            }

            if (idCategory != string.Empty)
            {
                Products = PagProduct.GetProductInCategoryPagination(PagProduct.CurrentPage, idCategory);
            } else
            {
                Products = PagProduct.GetProductPagination(PagProduct.CurrentPage);
            }
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

        public void ShowProductInCategory(int curr, string id)
        {
            ///danh sách sản phẩm theo danh mục
            if (id == "0")
            {
                ///nếu là số 0 thì xuất tất cả các sản phẩm.
                Products = PagProduct.GetProductPagination(curr);
            }
            else
            {
                Products = PagProduct.GetProductInCategoryPagination(curr, id);
            }
        }
    }
}
