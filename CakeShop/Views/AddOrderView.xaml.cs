using CakeShop.Models;
using Caliburn.Micro;
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
        GetListObject getlist = new GetListObject();

        public AddOrderView()
        {
            InitializeComponent();
            OrderDay.SelectedDate = DateTime.Today;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = Main.DataContext as AddOrderViewModel;
        }

      
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

        /// <summary>
        /// nút hoàn thành xữ lý trên giao diện.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            if (NameCustomer.Text.Trim() != string.Empty && EmailCustomer.Text.Trim() != string.Empty && AddressCustomer.Text.Trim() != string.Empty && Description.Text.Trim() != string.Empty && OrderDay.Text.Trim() != string.Empty)
            {
                var index = ComboboxStatus.SelectedIndex;///trang thái
                CurrentViewModel.AddOrder(NameCustomer.Text, EmailCustomer.Text, AddressCustomer.Text, Description.Text, OrderDay.Text, index);
            }
          
                /// goi hàm thêm vào database. sum là tổng tiền tất cả các sản phẩm
                CurrentViewModel.AddDetailOrder();
        }



        /// <summary>
        /// thêm sản phẩm đơn hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ADD_click(object sender, RoutedEventArgs e)
        {
            SizeProduct SizeOfProduct = ComboboxSize.SelectedValue as SizeProduct;
            if (ComboboxNameProduct.Text.Trim() != string.Empty && AmountProductTextbox.Text.Trim() != string.Empty && SizeOfProduct != null)
            {
                var size = SizeOfProduct.Size;

                //ten sản phẩm
                var index = ComboboxNameProduct.SelectedIndex;
                string Amount = AmountProductTextbox.Text.Trim();

                // Gọi phương thức từ ViewModel
                CurrentViewModel.AddToListbox(size, Amount, index);
            } else
            {
                MessageBox.Show("Nhập đầy đủ thông tin !", "Yêu cầu", MessageBoxButton.OK);
            }
        }

        private void ComboboxNameProduct_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            AmountProductTextbox.Text = "1";

            ComboBox CbBox = sender as ComboBox;
            Product productSelected = CbBox.SelectedValue as Product;
            string productId = productSelected.IdProduct;
            CurrentViewModel.BindingSizeProduct(productId);

            ComboboxSize.SelectedIndex = 0;
        }
    }
}
