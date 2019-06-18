using OZBAY.Core.Utilities.Helpers;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Entities.Concrete;
using MyShop.Northwind.MvcWebUI.Filters;
using MyShop.Northwind.MvcWebUI.Models;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyShop.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public int PageSize = 10;
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public ActionResult Index(int page = 1, int category = 0)
        {
            List<Product> products = GetProductListByCategory(category);
            string actionName = CookieHelper.GetPropertyNameFromCookies("action");
            string controllerName = CookieHelper.GetPropertyNameFromCookies("controller");
            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                Route = String.Format("/{0}/{1}", controllerName, actionName),
                Products = products.Skip((page - 1) * PageSize).Take(10).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count(),
                    CurrentPage = page,
                    CurrentCategory = category
                }
            };

            return View(productListViewModel);
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        private List<Product> GetProductListByCategory(int category)
        {
            return _productService.GetAll().Where(x => x.CategoryId == category || category == 0).ToList();
        }
    }
}