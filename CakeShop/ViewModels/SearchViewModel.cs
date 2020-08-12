using CakeShop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
    public class SearchViewModel:Screen
    {
        public string Keyword { get; set; }
        GetListObject Getlist = new GetListObject();
        Product product = new Product();
        public IEnumerable<Product> subnets;
        public IEnumerable<Product> SearchListproduct;
        PaginationProduct PagProduct = new PaginationProduct();
        public IEnumerable<Product> Products { get; set; }
        public BindableCollection<Category> CatogoryCombobox { get; set; }
        public SearchViewModel(string key)
        {
            //binding từ khóa tìm kiếm
            Keyword = "Kết quả tìm kiếm cho từ khóa '" + key + "'";

            //danh sách sản phẩm      
            SearchListproduct = SearchProductName(key);
            Products = SearchListproduct;
            
        }
        public IEnumerable<Product> SearchProductName(string keyword)
        {
            BindableCollection<Product> productlist = Getlist.Get_AllProduct();

            if (keyword == "")
            {
                return subnets;
            }
            else
            {
                subnets = productlist.Where(i => i.ProductName.ToLower().Contains(keyword.ToLower()));
            }
            return subnets;
        }
        public void ShowDetail(Product productSelected)
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            Conductor<IScreen>.Collection.OneActive MainConductor = (Conductor<IScreen>.Collection.OneActive)parentConductor;
            MainConductor.DeactivateItem(MainConductor.Items[0], true);
            parentConductor.ActivateItem(new DetailProductViewModel(productSelected.IdProduct));
        }

    }
}
