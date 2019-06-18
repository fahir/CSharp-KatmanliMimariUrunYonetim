using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using MyShop.Northwind.MvcWebUI.Filters;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyShop.Northwind.MvcWebUI.Controllers
{
    public class UserRoleController : Controller
    {
        private IUserRoleService _userRoleService;
        private IUserService _userService;
        private IRoleService _roleService;

        public UserRoleController(IUserRoleService userRoleService, IUserService userService, IRoleService roleService)
        {
            _userRoleService = userRoleService;
            _userService = userService;
            _roleService = roleService;
        }

        [SecuredOperation(Roles = "Admin")]
        [ExceptionHandler]
        public ActionResult Index()
        {
            UserRoleListViewModel userRoleListViewModel = new UserRoleListViewModel
            {
                UserRoleItemList = _userRoleService.GetAllItems()
            };
            return View(userRoleListViewModel);
        }

        [SecuredOperation(Roles = "Admin")]
        [ExceptionHandler]
        public ActionResult Edit(int userRoleId)
        {
            int userId = GetUserId(userRoleId);

            UserRoleUpdateViewModel userRoleUpdateViewModel = new UserRoleUpdateViewModel
            {
                UserRole = _userRoleService.Get(userRoleId),
                Roles = _roleService.GetAll(),
                User = _userService.Get(userId)

            };
            return View(userRoleUpdateViewModel);
        }

        [SecuredOperation(Roles = "Admin")]
        [ExceptionHandler]
        private int GetUserId(int userRoleId)
        {
            List<UserRoleItem> userRoleList = _userRoleService.GetAllItems().Where(x => x.Id == userRoleId).ToList();
            int userId = 0;
            foreach (var item in userRoleList)
            {
                userId = item.UserId;
            }
            return userId;
        }

        [SecuredOperation(Roles = "Admin")]
        [ExceptionHandler]
        [HttpPost]
        public ActionResult Edit(UserRole userRole)
        {
            _userRoleService.Update(userRole);
            return RedirectToAction("Index");
        }
    }
}