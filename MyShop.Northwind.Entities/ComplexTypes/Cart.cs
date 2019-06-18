using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Northwind.Entities.ComplexTypes
{
    public class Cart : IEntity
    {
        public virtual int CartId { get; set; }

        readonly List<CartLine> _cartLines = new List<CartLine>();

        public void AddToCart(Product product, int quantity)
        {
            CartLine cartLine = _cartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine == null)
            {
                _cartLines.Add(new CartLine { Product = product, Qunatity = quantity });
            }
            else
            {
                cartLine.Qunatity += quantity;
            }
        }
        public void RemoveFromCart(Product product)
        {
            _cartLines.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public decimal Total
        {
            get
            {
                return _cartLines.Sum(c => c.Product.UnitPrice * c.Qunatity);
            }
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
        public List<CartLine> Lines
        {
            get
            {
                return _cartLines;
            }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Qunatity { get; set; }
    }
}
