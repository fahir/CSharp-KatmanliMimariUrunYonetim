using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.MvcWebUI.Models
{
    public class ProductAddOrUpdateViewModel
    {
        public Product Product { get; set; }

        public List<Category> Categories { get; set; }

        public string CurrentCulture { get; set; }

        public string CultureDecimalSeperator { get; set; }

    }
}