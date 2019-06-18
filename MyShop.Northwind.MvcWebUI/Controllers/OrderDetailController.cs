using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.MvcWebUI.Filters;
using MyShop.Northwind.MvcWebUI.Models;
using Newtonsoft.Json;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using OZBAY.Core.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyShop.Northwind.MvcWebUI.Controllers
{
    public class OrderDetailController : Controller
    {
        private IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        public int PageSize = 5;
        [SecuredOperation(Roles = "Admin,Editor")]
        [ExceptionHandler]
        public ActionResult OrderList(int page = 1, int category = 0)
        {
            List<OrderDetailItem> orderDetailItemList = _orderDetailService.GetAllItems();
            string actionName = CookieHelper.GetPropertyNameFromCookies("action");
            string controllerName = CookieHelper.GetPropertyNameFromCookies("controller");

            CartLine cartList = new CartLine();
            string userName = "";
            bool isCompleted = false;
            int orderNumber = 0;
            foreach (var item in orderDetailItemList)
            {
                cartList = JsonConvert.DeserializeObject<CartLine>(item.List);
                userName = item.UserName;
                isCompleted = item.IsCompleted;
                orderNumber = item.OrderDetailId;
            }

            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel
            {
                OrderDetailItemList = orderDetailItemList.Skip((page - 1) * PageSize).Take(5).ToList(),
                CartList = cartList,
                UserName = userName,
                IsCompleted = isCompleted,
                OrderNumber = orderNumber,
                Route = String.Format("/{0}/{1}", controllerName, actionName),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = orderDetailItemList.Count(),
                    CurrentPage = page,
                    CurrentCategory = category
                }
            };
            return View(orderDetailViewModel);
        }
    }
}