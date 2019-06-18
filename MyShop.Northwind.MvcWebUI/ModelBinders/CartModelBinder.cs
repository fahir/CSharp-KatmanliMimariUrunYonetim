using MyShop.Northwind.Entities.ComplexTypes;
using System.Web.Mvc;

namespace MyShop.Northwind.MvcWebUI.ModelBinders
{
    public class CartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = (Cart)controllerContext.HttpContext.Session["cart"];
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session["cart"] = cart;
            }
            return cart;
        }
    }
}