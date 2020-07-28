
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
    public class UpdateProductViewModel : Screen
    {
        // Muốn lấy những hình ảnh mới thêm vào thì lấy CarouselTest.Count - _defaultImagesCount -> số ảnh lấy ở đầu list
        private int _defaultImagesCount { get; set; } = 0;

        public BindableCollection<string> CarouselTest { get; set; }
        public UpdateProductViewModel()
        {
            CarouselTest = new BindableCollection<string>
            {
                "/Resource/Images/Products/detail-test.jpg",
                "/Resource/Images/Products/1.jpg",
                "/Resource/Images/Products/2.jpg",
                "/Resource/Images/Products/3.jpg",
                "/Resource/Images/Products/4.jpg",
                "/Resource/Images/Products/5.jpg",
                "/Resource/Images/Products/6.jpg",
                "/Resource/Images/Products/7.jpg",
                "/Resource/Images/Products/8.jpg",
                "/Resource/Images/Products/9.jpg"
            };

            _defaultImagesCount = CarouselTest.Count;
        }

        /// <summary>
        /// Mở trang chi tiết
        /// </summary>
        public void ShowDetail()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailProductViewModel());
        }

        /// <summary>
        /// Phương thức xử lý update hình
        /// </summary>
        /// <param name="images"></param>
        public void UpdateImages(List<FileInfo> images)
        {
            foreach(var image in images)
            {
                // Thêm hình mới update vào đầu
                CarouselTest.Insert(0, image.FullName);
            }
        }
    }
}
