using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CakeShop.ViewModels
{
    public class CreatProductViewModel : Screen
    {
        public BindableCollection<string> CarouselTest { get; set; }
        public ImageSource AddAvatar { get; set; }

        public CreatProductViewModel()
        {
            //AddAvatar = new BitmapImage(new Uri(@"/Resource/Images/Products/detail-test.jpg", UriKind.Absolute));
            //AddAvatar = ImageSource;
            CarouselTest = new BindableCollection<string>
            {
                
            };
        }
    }
}
