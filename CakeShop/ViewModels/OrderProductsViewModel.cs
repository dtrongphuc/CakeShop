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
        Pagination PaginationOrder = new Pagination();
        List<int> PageNumbers;

        public BindableCollection<Order> OrdersDataGrid { get; set; }
        public BindableCollection<PaginationStyle> PaginationNumber { get; set; }

        public OrderProductsViewModel() 
        {
            OrdersDataGrid = PaginationOrder.GetOrderPagination(1);
            GetDetail.Find("1");
            UpdateOrdersPagination(1, false, false);
            PaginationNumber = new BindableCollection<PaginationStyle>();
        }

        public void ShowDetailOrder(Order index)
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
                if (PaginationOrder.CurrentPage > 1)
                {
                    PaginationOrder.CurrentPage--;

                }
            }
            else if (isNextClick)
            {
                if (PaginationOrder.CurrentPage < PaginationOrder.ToltalPage)
                {
                    PaginationOrder.CurrentPage++;
                }
            }

            if (currentPage == 0)
            {
                PaginationOrder.CurrentPage = PaginationOrder.ToltalPage;
            }
            else if (currentPage != -1)
            {
                PaginationOrder.CurrentPage = currentPage;
            }

            OrdersDataGrid = PaginationOrder.GetOrderPagination(PaginationOrder.CurrentPage);
            PageNumbers = PaginationOrder.GetPaginaitonNumbers();
        }

        public void SetStylePagination(Style defaultStyle, Style selectedStyle)
        {
            PaginationNumber.Clear();
            foreach (var number in PageNumbers)
            {
                Style myStyle = defaultStyle;
                if (number == PaginationOrder.CurrentPage)
                {
                    myStyle = selectedStyle;
                }
                PaginationNumber.Add(new PaginationStyle() { Number = number, PageBtnStyle = myStyle });
            }
        }
    }
}
