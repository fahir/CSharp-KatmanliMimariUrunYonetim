using OZBAY.Core.Entities;
using System;

namespace MyShop.Northwind.Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public int Id { get; set; }

        public int ShippingDetailId { get; set; }

        public int UserId { get; set; }

        public int CartId { get; set; }

        public DateTime OrderDate { get; set; }

        public bool IsCompleted { get; set; }

        public virtual Cart Carts { get; set; }

        public virtual User Users { get; set; }

        public virtual ShippingDetail ShippingDetails { get; set; }

    }
}
