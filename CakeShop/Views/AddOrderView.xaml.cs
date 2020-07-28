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
        public AddOrderView()
        {
            InitializeComponent();
            OrderDay.SelectedDate = DateTime.Today;
        }

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
    }
}
