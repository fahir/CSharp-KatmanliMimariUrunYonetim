using System.Web;

namespace MyShop.Northwind.MvcWebUI.Models
{
    public class CurrentUserViewModel
    {
        public string User = HttpContext.Current.User.Identity.Name.ToString();

    }
}