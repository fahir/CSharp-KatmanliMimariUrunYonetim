using OZBAY.Core.Entities;
using System.Collections.Generic;
namespace MyShop.Northwind.Entities.Concrete
{
    public partial class User : IEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Hashword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
