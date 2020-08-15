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

        public Product CurrentProduct { get; set; } = new Product();  
        public BindableCollection<Image> ImagesCarousel { get; set; }
        public BindableCollection<SizeProduct> SizeQuantify { get; set; }
        
        public string ImageSelectChange { get; set; }

        public DetailProductViewModel(string productId) 
        {
            CurrentProduct.Find(productId);

            //danh sách số lượng và size sản phẩm
            SizeQuantify = getListObject.Get_SizeProduct(productId);

            //danh sách các hình của sản phẩm
            ImagesCarousel = getListObject.Get_ImageProduct(productId);

            //ảnh đại diện sản phẩm
            ImageSelectChange = ImagesCarousel.Count > 0 ? ImagesCarousel.ElementAt(0).ImageUri : string.Empty;
        }

        /// <summary>
        /// Mở trang chủ
        /// </summary>
        public void ShowHome()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new HomeViewModel());
        }

        public void ShowUpdate()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            parentConductor.ActivateItem(new UpdateProductViewModel(CurrentProduct.IdProduct));
        }

        public void Delete()
        {
            CurrentProduct.Delete();
            ShowHome();
        }
    }
}
