using OZBAY.Core.Utilities.Helpers;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Entities.Concrete;
using MyShop.Northwind.MvcWebUI.Filters;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using OZBAY.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MyShop.Northwind.MvcWebUI.Models;

namespace MyShop.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IUserRoleService _userRoleService;

        public AccountController(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            string hash = HashwordHelper.GenerateSHA512String(password);
            User user = _userService.GetByUserNameAndPassword(userName, hash);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthenticationCookie(
                new Guid(), user.UserName,
                user.Email,
                DateTime.Now.AddMinutes(15),
                GetUserRolesFromDatabase(user),
                true,
                user.FirstName,
                user.LastName);

                string[] roles = CookieHelper.GetUserRolesFromCookie();
                string controllerName = "";
                foreach (var role in roles)
                {
                    if (role.Equals("Student"))
                    {
                        controllerName = "Product";
                    }
                    else if (role.Equals("Admin") || role.Equals("Editor"))
                    {
                        controllerName = "Admin";

                    }
                }
                return RedirectToAction("Index", controllerName);
            }
            return View();
        }

        public PartialViewResult CurrentUser(CurrentUserViewModel currentUserViewModel)
        {
            return PartialView(currentUserViewModel);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        private string[] GetUserRolesFromDatabase(Entities.Concrete.User user)
        {
            return _userService.GetUserRoles(user).Select(u => u.RoleName).ToArray();
        }

        [ExceptionHandler]
        public ActionResult Register()
        {
            UserAddOrUpdateViewModel userAddOrUpdateViewModel = new UserAddOrUpdateViewModel();

            return View(userAddOrUpdateViewModel);
        }

        [ExceptionHandler]
        [HttpPost]
        public ActionResult Register(UserAddOrUpdateViewModel userAddOrUpdateViewModel)
        {
            User user = new User
            {
                Email = userAddOrUpdateViewModel.User.Email,
                FirstName = userAddOrUpdateViewModel.User.FirstName,
                Hashword = HashwordHelper.GenerateSHA512String(userAddOrUpdateViewModel.User.Hashword),
                LastName = userAddOrUpdateViewModel.User.LastName,
                UserName = userAddOrUpdateViewModel.User.UserName,
            };
            string userName = userAddOrUpdateViewModel.User.UserName;
            string password = userAddOrUpdateViewModel.User.Hashword;
            int userId = _userService.Add(user).Id;
            UserRole userRole = new UserRole { RoleId = 3, UserId = userId };
            _userRoleService.Add(userRole);
            ActionResult action = new AccountController(_userService, _userRoleService).Login(userName, password);
            return action;
        }

    }
}