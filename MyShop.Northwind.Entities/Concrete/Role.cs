using OZBAY.Core.Entities;
using System.Collections.Generic;
namespace MyShop.Northwind.Entities.Concrete
{
    public partial class Role : IEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }

        public string RoleName { get; set; }


        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
