using System.Collections.Generic;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.MvcWebUI.Models;

namespace MyShop.Northwind.MvcWebUI
{
    public class OrderDetailViewModel
    {
        public PagingInfo PagingInfo { get; set; }
        public string Route { get; set; }
        public List<OrderDetailItem> OrderDetailItemList { get;  set; }
        public string UserName { get;  set; }
        public bool IsCompleted { get;  set; }
        public Entities.ComplexTypes.CartLine CartList { get;  set; }
        public int OrderNumber { get;  set; }
    }
}