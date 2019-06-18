using MyShop.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable("UserRoles", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id");
            Property(x => x.UserId).HasColumnName(@"UserID");
            Property(x => x.RoleId).HasColumnName(@"RoleId");

            // Foreign keys
            HasRequired(a => a.Role).WithMany(b => b.UserRoles).HasForeignKey(c => c.RoleId).WillCascadeOnDelete(false); // FK_UserRoles_ToTRole
            HasRequired(a => a.User).WithMany(b => b.UserRoles).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false); // FK_UserRoles_ToUser
        }
    }
}
