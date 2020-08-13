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
    public class OrderProductsViewModel : Screen
    {
        public GetListObject GetData = new GetListObject();
        public DetailOrder GetDetail = new DetailOrder();
        PaginationProduct PagProduct = new PaginationProduct();
        List<int> PageNumbers;

        public BindableCollection<Order> OrdersDataGrid { get; set; }
        public BindableCollection<Product> DetailDataGrid { get; set; }
        public BindableCollection<PaginationStyle> PaginationNumber { get; set; }

        public OrderProductsViewModel() 
        {
            OrdersDataGrid = GetData.Get_AllOrder();
            GetDetail.Find("1");
            DetailDataGrid = GetDetail.ListProduct;
            UpdateOrdersPagination(1, false, false);
            PaginationNumber = new BindableCollection<PaginationStyle>();
        }

        public void ShowDetailOrder(string index)
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailOrderViewModel(index));
        }

        public void UpdateOrdersPagination(int currentPage, bool isPrevClick, bool isNextClick)
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

            //Products = PagProduct.GetProductPagination(PagProduct.CurrentPage);
            PageNumbers = PagProduct.GetPaginaitonNumbers();
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
