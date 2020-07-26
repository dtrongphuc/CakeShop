
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
    public class UpdateProductViewModel : Screen
    {
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
        }

        public void ShowDetail()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailProductViewModel());
        }
    }
}
