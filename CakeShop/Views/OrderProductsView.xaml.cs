using CakeShop.Models;
using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CakeShop.Views
{
    /// <summary>
    /// Interaction logic for OrderProductsView.xaml
    /// </summary>
    public partial class OrderProductsView : UserControl
    {
        Style defaultStyle;
        Style selectedStyle;

        public OrderProductsViewModel CurrentViewModel { get; set; } = null;

        public OrderProductsView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = Main.DataContext as OrderProductsViewModel;
            SetStylePagination();
        }

        private void OrdersDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is DataGrid && !e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }

        private void SetStylePagination()
        {
            defaultStyle = this.FindResource("PaginationStyle") as Style;
            selectedStyle = this.FindResource("PaginationStyleSelected") as Style;
            CurrentViewModel.SetStylePagination(defaultStyle, selectedStyle);
        }

        /// <summary>
        /// Cập nhật lại số trang
        /// </summary>
        /// <param name="currentPage">Trang hiện tại (-1 nếu không muốn đặt, 0 nếu muốn về trang cuối)</param>
        /// <param name="isPrevClick">Có phải prev click không</param>
        /// <param name="isNextClick">Có phải next click không</param>
        private void UpdatePagination(int currentPage, bool isPrevClick, bool isNextClick)
        {
            CurrentViewModel.UpdateOrdersPagination(currentPage, isPrevClick, isNextClick);
            CurrentViewModel.SetStylePagination(defaultStyle, selectedStyle);
        }

        private void OnPageNumber_Click(object sender, RoutedEventArgs e)
        {
            var Btn = (Button)sender;
            int CurrPage = (int)Btn.Content;
            UpdatePagination(CurrPage, false, false);
        }

        private void OnPrePage_Click(object sender, RoutedEventArgs e)
        {
            UpdatePagination(-1, true, false);
        }

        private void OnNextPage_Click(object sender, RoutedEventArgs e)
        {
            UpdatePagination(-1, false, true);
        }

        private void OnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            UpdatePagination(1, false, false);
        }

        private void OnLastPage_Click(object sender, RoutedEventArgs e)
        {
            UpdatePagination(0, false, false);
        }

        private void Change_Status(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ViewDetail_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
        }
    }
}
