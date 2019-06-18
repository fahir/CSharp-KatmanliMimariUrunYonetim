using OZBAY.Core.Entities;
using System.Collections.Generic;

namespace MyShop.Northwind.Entities.Concrete
{
    public class Cart : IEntity
    {

        public Cart()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        public string CartList { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
