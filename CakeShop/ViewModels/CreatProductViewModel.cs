using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CakeShop.ViewModels
{
    public class CreatProductViewModel : Screen
    {
        public BindableCollection<string> ImagesCarousel { get; set; } = new BindableCollection<string>();
        public ImageSource AddAvatar { get; set; }

        public CreatProductViewModel()
        {
            //AddAvatar = new BitmapImage(new Uri(@"/Resource/Images/Products/detail-test.jpg", UriKind.Absolute));
            //AddAvatar = ImageSource;
            ImagesCarousel = new BindableCollection<string>
            {
               
            };
        }

        /// <summary>
        /// Phương thức xử lý update hình
        /// </summary>
        /// <param name="images"></param>
        public void UpdateImages(List<FileInfo> images)
        {
            foreach (var image in images)
            {
                // Thêm hình mới update vào đầu
                ImagesCarousel.Insert(0, image.FullName);
            }
        }
    }
}
