using OZBAY.Core.Entities;
using System.Collections.Generic;

namespace MyShop.Northwind.Entities.Concrete
{
    public class ShippingDetail : IEntity
    {
        public ShippingDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Address1 { get; set; }

        public virtual string Address2 { get; set; }

        public virtual string City { get; set; }

        public virtual string Country { get; set; }

        public virtual bool IsGift { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
