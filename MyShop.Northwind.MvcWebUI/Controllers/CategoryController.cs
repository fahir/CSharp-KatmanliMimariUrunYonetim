using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.MvcWebUI.Filters;
using MyShop.Northwind.MvcWebUI.Models;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using System.Web.Mvc;

namespace MyShop.Northwind.MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public ActionResult Index()
        {
            return View();
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public PartialViewResult List(string controllerName, string actionName, int category = 0)
        {
            CategoryListViewModel categoryListViewModel = new CategoryListViewModel
            {
                ControllerName = controllerName,
                ActionName = actionName,
                Categories = _categoryService.GetAll(),
                CurrentCategory = category
            };
            return PartialView(categoryListViewModel);
        }
    }
}