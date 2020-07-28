using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CakeShop.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void BtnShowMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", BtnHideMenu, BtnShowMenu, Menu);
        }

        private void BtnHideMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", BtnHideMenu, BtnShowMenu, Menu);
        }

        private void Modal_Click(object sender, MouseButtonEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", BtnHideMenu, BtnShowMenu, Menu);
        }

        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, Grid pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }

        // Khi click vào nút tìm kiếm
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Show();
            var config = ConfigurationManager.AppSettings["ShowSplash"];
            if (config.ToLower() == "true")
            {
                var screen = new Views.SplashWindow();
                screen.ShowDialog();
            }
        }

        private void HideMenuAndModal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", BtnHideMenu, BtnShowMenu, Menu);
        }
    }
}
