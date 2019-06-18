using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyShop.Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> GetAll()
        {          
            return _productService.GetAll();
        }


        [HttpPost]
        public Product Add(Product product)
        {
            return _productService.Add(product);
        }

        [HttpPut]
        public Product Update(Product product)
        {
            return _productService.Update(product);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            Product product = _productService.Get(id);
            if (product != null)
            {
                _productService.Delete(product);
                return "Product Deleted Id:" + id;
            }
            return "Product Not Deleted Id: "+id;
        }

    }
}
