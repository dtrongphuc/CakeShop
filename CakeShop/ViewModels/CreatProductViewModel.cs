using CakeShop.Models;
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

        string folderfile = AppDomain.CurrentDomain.BaseDirectory;
        public string AddProduct(string name, int idcata, string price, string des, FileInfo listImage)
        {
            var avartar = "";


            Product product = new Product();
            product.IdCategory = (idcata + 1).ToString();
            product.ProductName = name.Trim();
            product.Price = price.Trim();
            product.Description = des.Trim();
            if (listImage.Name != null)
            {
                avartar = $"{Guid.NewGuid()}{listImage.Extension}";
                listImage.CopyTo($"{folderfile}Resource\\Images\\Products\\{avartar}");
                product.Image = $"/Resource/Images/Products/{avartar}";
            }
            product.Add();
            return avartar;
        }

        public void AddImageProduct(List<FileInfo> ImagesFileList, int _ImagesAddCount, string avartar)
        {
            Models.Image image = new Models.Image();
            image.ImagUri = $"/Resource/Images/Products/{avartar}";
            image.Add();
            for (int i = 1; i < _ImagesAddCount; i++)
            {
                if (ImagesFileList[i].Name != null)
                {
                    avartar = $"{Guid.NewGuid()}{ImagesFileList[i].Extension}";
                    ImagesFileList[i].CopyTo($"{folderfile}Resource\\Images\\Products\\{avartar}");
                    image.ImagUri = $"/Resource/Images/Products/{avartar}";
                    image.Add();
                }
            }
        }

        public void AddSizeProduct(List<SizeProduct> _listSize)
        {
            foreach (var size in _listSize)
            {
                size.Add();
            }
        }


    }
}
