using CakeShop.Models;
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
        GetListObject Getlist = new GetListObject();
        public BindableCollection<string> ImagesCarousel { get; set; }
        public BindableCollection<Category> ComboboxCategoryBD { get; set; }
        public ImageSource AddAvatar { get; set; }

        public CreatProductViewModel()
        {
            //AddAvatar = new BitmapImage(new Uri(@"/Resource/Images/Products/detail-test.jpg", UriKind.Absolute));
            //AddAvatar = ImageSource;
            ImagesCarousel = new BindableCollection<string>
            {
                
            };

            //liệt kê trong các danh mục trong combobox
            ComboboxCategoryBD = Getlist.Get_AllCategory();
        }
    }
}
