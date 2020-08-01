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
        public BindableCollection<Product> Products { get; set; } = new BindableCollection<Product>();
        public BindableCollection<Category> CatogoryCombobox { get; set; }
        public SearchViewModel(string key)
        {
            //binding từ khóa tìm kiếm
            Keyword = "Kết quả tìm kiếm cho từ khóa '" + key + "'";

            //danh sách sản phẩm      
            SearchListproduct = SearchProductName(key);
            if (SearchListproduct.Count() != 0)
            {
                List<string> IDproducts = new List<string>();
                foreach (var item in SearchListproduct)
                {
                    if (!IDproducts.Contains(item.IdProduct))
                    {
                        IDproducts.Add(item.IdProduct);
                        product.Find(item.IdProduct);
                        //Add vào list binding
                        Products.Insert(0, product);
                    }
                }
            }
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
