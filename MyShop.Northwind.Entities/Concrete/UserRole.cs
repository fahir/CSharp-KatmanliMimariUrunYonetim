using OZBAY.Core.Entities;
namespace MyShop.Northwind.Entities.Concrete
{
    public partial class UserRole : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
