using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;
namespace MyShop.Northwind.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Route { get; set; }

        public Product Product { get; set; }

    }
}