using CakeShop.Models;
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
    /// Interaction logic for AddOrderView.xaml
    /// </summary>
    public partial class AddOrderView : UserControl
    {
        AddOrderViewModel CurrentViewModel = null;
        public AddOrderView()
        {
            InitializeComponent();
            OrderDay.SelectedDate = DateTime.Today;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = Main.DataContext as AddOrderViewModel;
        }

        private int sum=0;
        private List<DetailOrder> listOrder = new List<DetailOrder>();

        private void BtnMinusNumProduct_Click(object sender, RoutedEventArgs e)
        {
            int Amountproduct = int.Parse(AmountProductTextbox.Text.Trim());

            if (Amountproduct != 1)
            {
                Amountproduct--;
                AmountProductTextbox.Text = string.Empty;
                AmountProductTextbox.Text = Amountproduct.ToString();
            }
        }

        private void BtnPlusNumProduct_Click(object sender, RoutedEventArgs e)
        {
            int Amountproduct = int.Parse(AmountProductTextbox.Text.Trim());
            Amountproduct++;
            AmountProductTextbox.Text = string.Empty;
            AmountProductTextbox.Text = Amountproduct.ToString();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
           if(listOrder.Count>0)
            {
                ///goi hàm thêm vào database. sum là tổng tiền tất cả các sản phẩm
                CurrentViewModel.AddDetailOrder(listOrder);
            }
           

            if(NameCustomer.Text.Trim() != string.Empty && EmailCustomer.Text.Trim() != string.Empty && AddressCustomer.Text.Trim() != string.Empty && Description.Text.Trim() != string.Empty && OrderDay.Text.Trim() != string.Empty)
            {
                var index = CoboboxStatus.SelectedIndex;//trang thái
                CurrentViewModel.AddOrder(NameCustomer.Text, EmailCustomer.Text, AddressCustomer.Text, Description.Text, OrderDay.Text,index, sum);
            }



        }

        private void Them_click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            if (CoboboxNameProduct.Text.Trim() != string.Empty && AmountProductTextbox.Text.Trim() != string.Empty)
            {
               
                ComboBoxItem selected = CoboboxSize.SelectedValue as ComboBoxItem;
                TextBlock selectedTextBlock = selected.Content as TextBlock;
                var size = selectedTextBlock.Text;

                var index = CoboboxNameProduct.SelectedIndex;

                product.Find((index + 1).ToString());

                DetailOrder detail = new DetailOrder();
                product.Find((index + 1).ToString());
                int totalprice = int.Parse(product.Price) * int.Parse(AmountProductTextbox.Text);
                detail.PriceTotal = totalprice.ToString();
                detail.Quantity = AmountProductTextbox.Text;
                detail.IdProduct = (index + 1).ToString();
                detail.Size = size;
                sum += totalprice;
                listOrder.Add(detail);
            }
        }

        private void CoboboxNameProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = CoboboxNameProduct.SelectedItem as Product;
            CurrentViewModel.BindingPriceProduct(product.IdProduct);
        }
    }
}
