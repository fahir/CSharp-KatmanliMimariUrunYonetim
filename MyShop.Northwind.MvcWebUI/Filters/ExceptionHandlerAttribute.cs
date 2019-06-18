using System.Web.Mvc;
using System.Web.Routing;

namespace MyShop.Northwind.MvcWebUI.Filters
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string message = filterContext.Exception.Message;
            if (message.Equals("You are not authorized!"))
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                                       { "action", "Login" },
                                       { "controller", "Account" }
               });
            }

        }

    }
}