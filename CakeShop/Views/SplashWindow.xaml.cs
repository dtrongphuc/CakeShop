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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CakeShop.Views
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();
        }

        List<string> _content = new List<string>()
        {
            "Mùa hè mà ăn 1 cái bánh việt quất thì thế nào nhờ 🤤",
            "Tâm trạng bạn đang tồi tệ á?? Mlemm ngay chiếc bánh ngọt Brooklyn nào 🍰",
            "Cặp đôi thì ăn bánh Meringue, nó khiến cho tình cảm bạn nồng nàn hơn đóaaaa ♥",
            "Uầy bạn đang FA 😳, ra tiệm rinh ngay cái bánh ngọt về nhăm nhi cho yêu đời thuiiii",
            "Bạn đang giảm cân? Bạn thích bánh ngọt 😵 Vẫn có bánh Chocolate giảm cân nhá",
            "Đến Hà Nội thì đừng quên nếm thử bánh Paris Gateaux nha nha, tuyệt 🤤 "
        };

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkboxdisplay.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ShowSplash"].Value = "false";
                config.Save(ConfigurationSaveMode.Modified);
            }
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random _rng = new Random();
            int index = _rng.Next(0, (_content.Count - 1));
            var content_wellcome = _content[index];
            ContentWellcome.DataContext = content_wellcome;
        }
    }
}
