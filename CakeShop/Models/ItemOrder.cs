using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class ItemOrder
    {

        public string IdProduct { get; set; }

        public string ProductName { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Quantity { get; set; }

        public string Size { get; set; }

        public string PriceTotal { get; set; }
        
        public ItemOrder()
        {
            IdProduct = "";
            ProductName = "";
            Price = "";
            Description = "";
            Image = "";
            Quantity = "";
            Size = "";
        }

        public void Find(string id)
        {
            Product product = new Product();
            product.Find(id);
            this.IdProduct = product.IdProduct;
            this.ProductName = product.ProductName;
            this.Price = product.Price;
            this.Description = product.Description;
            this.Image = product.Image;
        }
    }
}
