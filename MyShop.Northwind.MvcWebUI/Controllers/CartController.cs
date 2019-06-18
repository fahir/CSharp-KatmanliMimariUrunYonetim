using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Entities.Concrete;
using MyShop.Northwind.MvcWebUI.Filters;
using MyShop.Northwind.MvcWebUI.Models;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using System;
using System.Web.Mvc;

namespace MyShop.Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;
        private ICartService _cartService;
        private IShippingDetailService _shippingDetailService;
        private IOrderDetailService _orderDetailService;
        private IUserService _userService;
        public CartController(IProductService productService, ICartService cartService, IShippingDetailService shippingDetailService, IOrderDetailService orderDetailService, IUserService userService)
        {
            _productService = productService;
            _cartService = cartService;
            _shippingDetailService = shippingDetailService;
            _orderDetailService = orderDetailService;
            _userService = userService;
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public RedirectToRouteResult AddToCart(Entities.ComplexTypes.Cart cart, int productId)
        {
            Product product = _productService.Get(productId);
            cart.AddToCart(product, 1);
            return RedirectToAction("Index", cart);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public ViewResult Index(Entities.ComplexTypes.Cart cart)
        {
            return View(cart);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public RedirectToRouteResult RemoveFromCart(Entities.ComplexTypes.Cart cart, int productId)
        {
            Product product = _productService.Get(productId);
            cart.RemoveFromCart(product);
            return RedirectToAction("Index", cart);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public ActionResult Checkout(Entities.ComplexTypes.Cart cart)
        {
            CartViewModel cartViewModel = new CartViewModel
            {
                ShippingDetail = new ShippingDetail(),
                Cart = cart
            };
            return View(cartViewModel);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        [HttpPost]
        public ActionResult Checkout(CartViewModel cartViewModel, Entities.ComplexTypes.Cart cart)
        {
            var cartList = cart;
            string cartListToJSON = Newtonsoft.Json.JsonConvert.SerializeObject(cartList);
            string userName = User.Identity.Name;
            int userId = GetUserIdByUserName(userName);
            int shippingDetailId = GetShippingDetailId(cartViewModel);
            int cartId = GetCartId(cartListToJSON);
            int OrderDetailId = GetOrderDetailId(userId, shippingDetailId, cartId);
            cart.Clear();
            CompletedViewModel completedViewModel = new CompletedViewModel
            {
                UserName = User.Identity.Name,
                OrderdetailId = OrderDetailId

            };
            return RedirectToAction("Completed", "Cart", completedViewModel);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        private int GetOrderDetailId(int userId, int shippingDetailId, int cartId)
        {
            return _orderDetailService.Add(
                           new OrderDetail
                           {
                               CartId = cartId,
                               OrderDate = DateTime.Now,
                               ShippingDetailId = shippingDetailId,
                               UserId = userId,
                               IsCompleted = false

                           }).Id;
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        private int GetCartId(string cartListToJSON)
        {
            return _cartService.Add(new Entities.Concrete.Cart
            {
                CartList = cartListToJSON
            }).Id;
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        private int GetUserIdByUserName(string userName)
        {
            return _userService.GetByUserName(userName).Id;
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        private int GetShippingDetailId(CartViewModel cartViewModel)
        {
            return _shippingDetailService.Add(new ShippingDetail
            {
                Address1 = cartViewModel.ShippingDetail.Address1,
                Address2 = cartViewModel.ShippingDetail.Address2,
                City = cartViewModel.ShippingDetail.City,
                Country = cartViewModel.ShippingDetail.Country,
                Name = cartViewModel.ShippingDetail.Name,
                IsGift = cartViewModel.ShippingDetail.IsGift
            }).Id;
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public ActionResult Completed(CompletedViewModel completedViewModel)
        {
            return View(completedViewModel);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [ExceptionHandler]
        public PartialViewResult CartSummary(Entities.ComplexTypes.Cart cart)
        {
            return PartialView(cart);
        }

    }
}