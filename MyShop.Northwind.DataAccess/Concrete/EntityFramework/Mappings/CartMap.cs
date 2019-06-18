using MyShop.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            ToTable("Carts", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id");
            Property(x => x.CartList).HasColumnName(@"CartList");
        }
    }
}
