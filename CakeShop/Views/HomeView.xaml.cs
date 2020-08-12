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
using CakeShop.Models;
using Caliburn.Micro;
using CakeShop.ViewModels;

namespace CakeShop.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        HomeViewModel CurrentViewModel = null;
        public HomeView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = GridMain.DataContext as HomeViewModel;
        }

        // Pagination
        private void UpdatePagination()
        {
            //SetStylePagination();
            //_list = Pages.GetSPPagination(Pages.CurrentPage);
            //PaginationNumber.ItemsSource = PageStyleList;
            //Products.ItemsSource = _list;
        }

        private void OnPageNumber_Click(object sender, RoutedEventArgs e)
        {
            //var Btn = (Button)sender;
            //Pages.CurrentPage = (int)Btn.Content;
            //UpdatePagination();
        }

        private void OnPrePage_Click(object sender, RoutedEventArgs e)
        {
            //if (Pages.CurrentPage > 1)
            //{
            //    Pages.CurrentPage--;
            //    UpdatePagination();
            //}
        }

        private void OnNextPage_Click(object sender, RoutedEventArgs e)
        {
            //if (Pages.CurrentPage < Pages.ToltalPage)
            //{
            //    Pages.CurrentPage++;
            //    UpdatePagination();
            //}
        }

        private void OnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            //Pages.CurrentPage = 1;
            //UpdatePagination();
        }

        private void OnLastPage_Click(object sender, RoutedEventArgs e)
        {
            //Pages.CurrentPage = Pages.ToltalPage;
            //UpdatePagination();
        }

        private void ProductInCategory(object sender, SelectionChangedEventArgs e)
        {
            var category = (Category.SelectedIndex+1).ToString();
            if (CurrentViewModel != null)
            {
                CurrentViewModel.ShowProductInCategory(1, category);
               
            }

        }

     
    }
}
