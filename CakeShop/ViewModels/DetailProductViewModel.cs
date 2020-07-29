using CakeShop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
    public class DetailProductViewModel : Screen
    {
        GetListObject getListObject = new GetListObject();
        SizeProduct sizeProduct = new SizeProduct();
        Product product = new Product();  
        public BindableCollection<string> ImagesCarousel { get; set; }
        public BindableCollection<SizeProduct> SizeQuantify { get; set; }
        public BindableCollection<Image> ImagesCarouselList { get; set; }
        
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Descriptiontext { get; set; }
        public string ImageSelectChange { get; set; }
        public DetailProductViewModel(string productId) 
        {
            product.ChooesProduct(productId);
            //tên sản phẩm
            ProductName = product.ProductName;
            //giá sản phẩm
            Price = product.Price;
            //mô tả sản phẩm
            Descriptiontext = product.Description;
            //danh sách số lượng và size sản phẩm
            SizeQuantify = getListObject.Get_SizeProduct(productId);
            //danh sách các hình của sản phẩm
            ImagesCarouselList = getListObject.Get_ImageProduct(productId);
            //ảnh đại diện sản phẩm
            ImageSelectChange = product.Image;
        }

        public void ShowUpdate()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            parentConductor.ActivateItem(new UpdateProductViewModel());
        }
    }
}
