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

namespace CakeShop.Views
{
    public class AddOrderViewModel : Screen
    {
        Product product = new Product();
        GetListObject GetList = new GetListObject();
        public string PriceProduct { get; set; }
        private int sum = 0;
        //tổng giá 1 sản phẩm 
        private string _totalPriceProductsTextBlock;
        public string TotalPriceProductsTextblock
        {
            get { return _totalPriceProductsTextBlock; }
            set
            {
                _totalPriceProductsTextBlock = value;
                NotifyOfPropertyChange(() => TotalPriceProductsTextblock);
            }
        }
        public BindableCollection<Product> ProductsNameCombobox { get; set; }
        private List<DetailOrder> listOrder = new List<DetailOrder>();
        public BindableCollection<dynamic> OrderedList { get; set; } = new BindableCollection<dynamic>();

        public AddOrderViewModel()
        {
            ProductsNameCombobox = GetList.Get_AllProduct();
            TotalPriceProductsTextblock = "0";
        }
        public void AddOrder(string name, string email, string address, string des, string date, int status)
        {
            Order order = new Order();
            order.CustomerName = name;
            order.Email = email;
            order.Address = address;
            order.Note = des;
            order.Date = date;
            order.Status = status.ToString();
            order.Total = sum.ToString();
            order.Add();
        }

        public void AddDetailOrder()
        {
            foreach(var detail in listOrder)
            {
                detail.Add();
            }
        }

        //binding gia sản phẩm tương ứng
        public void BindingPriceProduct(string idproduct)
        {
            product.Find(idproduct);
            PriceProduct = product.Price;
        }

       
        
        public void AddToListbox(string Size, string Amount,int index)//Productname, Priceproduct, Size, Amount
        {
            Product product = new Product();

            DetailOrder detail = new DetailOrder();
            product.Find((index + 1).ToString());
            //thành tiền sản phẩm
            int totalprice = int.Parse(product.Price) * int.Parse(Amount);
            detail.PriceTotal = totalprice.ToString();
            detail.Quantity = Amount;
            detail.IdProduct = (index + 1).ToString();
            detail.Size = Size;
            sum += totalprice;

            //binding
            OrderedList.Insert(0, GetList.Get_ProductAndSizeProduct(detail, product));

            listOrder.Add(detail);

            //binding tổng tiền
            TotalPriceProductsTextblock = sum.ToString();
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
