using MyShop.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Roles", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id");
            Property(x => x.RoleName).HasColumnName(@"RoleName");
        }
    }
}
