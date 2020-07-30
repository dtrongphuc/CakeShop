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
                    //if (!IDproducts.Contains(item.IdProduct))
                    //{
                    //    IDproducts.Add(item.IdProduct);
                    //    dynamic productsearch = product.Find(item.IdProduct);
                    //    Products.Add(productsearch);
                    //}
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

    }
}
