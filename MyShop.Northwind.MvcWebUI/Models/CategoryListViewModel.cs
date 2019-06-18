using System.Collections.Generic;
using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }
        public string ControllerName { get; internal set; }
        public string ActionName { get; internal set; }
    }
}