using CakeShop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CakeShop.ViewModels
{
    public class SearchViewModel : Screen
    {
        public string Keyword { get; set; }
        GetListObject Getlist = new GetListObject();
        public IEnumerable<Product> subnets;
        public IEnumerable<Product> SearchListproduct;
        Pagination PagProduct = new Pagination();
        public IEnumerable<Product> Products { get; set; }
        public BindableCollection<Category> CatogoryCombobox { get; set; }
        public BindableCollection<PaginationStyle> PaginationNumber { get; set; }
        List<int> PageNumbers;

        public SearchViewModel(string key)
        {
            //binding từ khóa tìm kiếm
            Keyword = "Kết quả tìm kiếm cho từ khóa '" + key + "'";
            UpdateProductsPagination(1, false, false);
            PaginationNumber = new BindableCollection<PaginationStyle>();
        }
        public IEnumerable<Product> SearchProductName(string keyword)
        {
            BindableCollection<Product> productlist = Getlist.Get_AllProduct();

            if (keyword == "")
            {
                return subnets;
            }
            else
            {
                subnets = productlist.Where(i => i.ProductName.ToLower().Contains(keyword.ToLower()));
            }
            return subnets;
        }

        public void ShowDetail(Product productSelected)
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailProductViewModel(productSelected.IdProduct));
        }

        public void UpdateProductsPagination(int currentPage, bool isPrevClick, bool isNextClick)
        {
            if (isPrevClick)
            {
                if (PagProduct.CurrentPage > 1)
                {
                    PagProduct.CurrentPage--;

                }
            }
            else if (isNextClick)
            {
                if (PagProduct.CurrentPage < PagProduct.ToltalPage)
                {
                    PagProduct.CurrentPage++;
                }
            }

            if (currentPage == 0)
            {
                PagProduct.CurrentPage = PagProduct.ToltalPage;
            }
            else if (currentPage != -1)
            {
                PagProduct.CurrentPage = currentPage;
            }

            //Products = SearchProductName(key);
            PageNumbers = PagProduct.GetPaginaitonNumbers(PagProduct.record1pageProduct);
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
