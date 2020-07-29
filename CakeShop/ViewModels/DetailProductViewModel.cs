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
        public BindableCollection<string> ImagesCarousel { get; set; }
        
        public DetailProductViewModel() 
        {
        }

        public void ShowUpdate()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            parentConductor.ActivateItem(new UpdateProductViewModel());
        }
    }
}
