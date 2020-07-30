
using CakeShop.Models;
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
        GetListObject getListObject = new GetListObject();
        Product product = new Product();
        public BindableCollection<Image> ImagesCarousel { get; set; }
        public BindableCollection<SizeProduct> SizeQuantify { get; set; }
        string folderfile = AppDomain.CurrentDomain.BaseDirectory;
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Descriptiontext { get; set; }
        public string ImageSelectChange { get; set; }
        public UpdateProductViewModel(string idProduct)
        {
            product.Find(idProduct);

            //tên sản phẩm
            ProductName = product.ProductName;

            //giá sản phẩm
            Price = product.Price;

            //mô tả sản phẩm
            Descriptiontext = product.Description;

            //danh sách số lượng và size sản phẩm
            SizeQuantify = getListObject.Get_SizeProduct(idProduct);

            //danh sách các hình của sản phẩm
            ImagesCarousel = getListObject.Get_ImageProduct(idProduct);

            _defaultImagesCount = ImagesCarousel.Count;
        }

        /// <summary>
        /// Mở trang chi tiết 
        /// </summary>
        public void ShowDetail()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailProductViewModel(product.IdProduct));
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
                Image imageuri = new Image();
                imageuri.ImageUri = image.FullName;
                ImagesCarousel.Insert(0, imageuri);
            }
        }
        
        
        public string UpdateProduct(FileInfo listimage, string name, string price, string des)
        {
            string avartar="";
            product.ProductName = name;
            product.Price = price;
            product.Description = des;
            if (listimage.Name != null)
            {
                avartar = $"{Guid.NewGuid()}{listimage.Extension}";
                listimage.CopyTo($"{folderfile}Resource\\Images\\Products\\{avartar}");
                product.Image = $"/Resource/Images/Products/{avartar}";
            }
            product.Update();
            return avartar;
        }

        public string UpdateProductNoAvartar( string name, string price, string des)
        {
            string avartar = "";
            product.ProductName = name;
            product.Price = price;
            product.Description = des;
            product.Update();
            return avartar;
        }

        public void UpdateImageProduct(List<FileInfo> listimages, string avartar)
        {

            Image image = new Image();
            image.ImageUri = $"/Resource/Images/Products/{avartar}";
            image.IdProduct = product.IdProduct;
            image.Update();
            for (int i = 1; i < listimages.Count; i++)
            {
                if (listimages[i].Name != null)
                {
                    avartar = $"{Guid.NewGuid()}{listimages[i].Extension}";
                    listimages[i].CopyTo($"{folderfile}Resource\\Images\\Products\\{avartar}");
                    image.ImageUri = $"/Resource/Images/Products/{avartar}";
                    image.Update();
                }
            }
        }
        
        public void UpadateSizeProduct()
        {
            foreach(var size in SizeQuantify)
            {
                size.Update();
            }
        }    
    }
}
