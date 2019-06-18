using MyShop.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("OrderDetail", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id");
            Property(x => x.ShippingDetailId).HasColumnName(@"ShippingDetailId");
            Property(x => x.UserId).HasColumnName(@"UserId");
            Property(x => x.CartId).HasColumnName(@"CartId");

            // Foreign keys
            HasRequired(a => a.Carts).WithMany(b => b.OrderDetails).HasForeignKey(c => c.CartId); // OrderDetail_FK_2
            HasRequired(a => a.ShippingDetails).WithMany(b => b.OrderDetails).HasForeignKey(c => c.ShippingDetailId); // OrderDetail_FK_1
            HasRequired(a => a.Users).WithMany(b => b.OrderDetails).HasForeignKey(c => c.UserId); // OrderDetail_FK
        }
    }
}

