﻿
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
        //private int _defaultImagesCount { get; set; } = 0;
        GetListObject getListObject = new GetListObject();
        Product product = new Product();
        public BindableCollection<Image> ImagesCarousel { get; set; }
        public BindableCollection<SizeProduct> SizeQuantify { get; set; }

        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Descriptiontext { get; set; }
        public string ImageSelectChange { get; set; }
        public UpdateProductViewModel(string idProduct)
        {
            product.ChooesProduct(idProduct);

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
            
        }

        /// <summary>
        /// Mở trang chi tiết 
        /// </summary>
        /// <param name="productSelected">Sản phẩm được chọn</param>
        public void ShowDetail(Product productSelected)
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailProductViewModel(productSelected.IdProduct));
        }

        public string ConvertImaes(string image)//		image.FullName	"C:\\Users\\Nghia_DX\\Pictures\\646447.jpg"	string
        {
            string imageconvet = "";
            for (int i = image.Length-1; i > 0; i--)
            {
                if(image[i] == '\\')
                {
                    imageconvet = image.Substring(i+1, (image.Length - 1 - i));
                    break;    
                }
            }
            return imageconvet;
        }

        Image image1 = new Image();
        /// <summary>
        /// Phương thức xử lý update hình
        /// </summary>
        /// <param name="images"></param>
        public void UpdateImages(List<FileInfo> images)//_imageUri	"/Resource/Images/Products/sandwichgiambong1.jpg"
        {
            foreach (var image in images)
            {
                // Thêm hình mới update vào đầu    
                image1.ImageUri = "/Resource/Images/Products/" + ConvertImaes(image.FullName);
                ImagesCarousel.Insert(0, image1);
            }
        }      
    }
}
