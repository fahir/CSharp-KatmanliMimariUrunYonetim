using MyShop.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ShippingDetailMap : EntityTypeConfiguration<ShippingDetail>
    {
        public ShippingDetailMap()
        {
            ToTable("ShippingDetails", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id");
            Property(x => x.Name).HasColumnName(@"Name");
            Property(x => x.Address1).HasColumnName(@"Address1");
            Property(x => x.Address2).HasColumnName(@"Address2");
            Property(x => x.City).HasColumnName(@"City");
            Property(x => x.Country).HasColumnName(@"Country");
            Property(x => x.IsGift).HasColumnName(@"IsGift");
        }
    }
}
