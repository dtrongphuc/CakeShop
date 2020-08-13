using CakeShop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeShop.Views;
using System.IO;
using System.IO.Packaging;
using CakeShop.ViewModels;

namespace CakeShop.Models
{
    public class DetailOrderViewModel : Screen
    {
        public DetailOrderViewModel()
        {

        }
        public void ShowOrder()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new OrderProductsViewModel());
        }
    }

    
}
