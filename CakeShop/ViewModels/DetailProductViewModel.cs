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
        //public DetailProductViewModel(string productId) { }
        public BindableCollection<string> CarouselTest { get; set; }
        
        public DetailProductViewModel() 
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
        }

        public void ShowUpdate()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            parentConductor.ActivateItem(new UpdateProductViewModel());
        }
    }
}
