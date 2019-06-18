using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.MvcWebUI.Models
{
    public class CartViewModel
    {
        public ShippingDetail ShippingDetail { get; set; }
        public Entities.ComplexTypes.Cart Cart { get; set; }
    }
}