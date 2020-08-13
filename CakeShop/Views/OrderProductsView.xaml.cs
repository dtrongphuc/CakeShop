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
        public OrderProductsViewModel CurrentViewModel { get; set; } = null;

        public OrderProductsView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = Main.DataContext as OrderProductsViewModel;
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

        private void Change_Status(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void OnFirstPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnPageNumber_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnLastPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnNextPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnPrePage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewDetail_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CurrentViewModel.ShowDetailOrder();
        }
    }
}
