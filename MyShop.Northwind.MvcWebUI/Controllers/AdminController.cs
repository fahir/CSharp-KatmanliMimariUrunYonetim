using OZBAY.Core.Utilities.Helpers;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Entities.Concrete;
using MyShop.Northwind.MvcWebUI.Filters;
using MyShop.Northwind.MvcWebUI.Models;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace MyShop.Northwind.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public int PageSize = 10;
        [SecuredOperation(Roles = "Admin,Editor")]
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
        [SecuredOperation(Roles = "Admin,Editor")]
        [ExceptionHandler]
        public ActionResult Create()
        {
            ProductAddOrUpdateViewModel model = new ProductAddOrUpdateViewModel
            {
                Product = new Product(),
                Categories = GetCategoryList(),
                CurrentCulture = CultureInfo.CurrentCulture.Name,
                CultureDecimalSeperator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator
            };
            return View(model);
        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [ExceptionHandler]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            _productService.Add(product);
            return RedirectToAction("Index");
        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [ExceptionHandler]
        private List<Category> GetCategoryList()
        {
            return _categoryService.GetAll();

        }

        //  [SecuredOperation(Roles = "Admin,Editor")]
        [ExceptionHandler]
        public ActionResult Edit(int productId)
        {

            ProductAddOrUpdateViewModel productAddOrUpdateModel = new ProductAddOrUpdateViewModel
            {
                Product = _productService.Get(productId),
                Categories = GetCategoryList(),
                CurrentCulture = CultureInfo.CurrentCulture.Name,
                CultureDecimalSeperator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator
            };
            return View(productAddOrUpdateModel);
        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [ExceptionHandler]
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");
        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [ExceptionHandler]
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            var product = _productService.Get(productId);
            _productService.Delete(product);
            return RedirectToAction("Index");

        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [ExceptionHandler]
        private List<Product> GetProductListByCategory(int category)
        {
            return _productService.GetAll().Where(x => x.CategoryId == category || category == 0).ToList();
        }
    }
}