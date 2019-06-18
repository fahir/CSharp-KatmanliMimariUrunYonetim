using System.Data.Entity.ModelConfiguration;
using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Products", @"dbo");
            HasKey(x => x.ProductId);

            Property(x => x.ProductId).HasColumnName(@"ProductID");
            Property(x => x.ProductName).HasColumnName(@"ProductName");
            Property(x => x.SupplierId).HasColumnName(@"SupplierID");
            Property(x => x.CategoryId).HasColumnName(@"CategoryID");
            Property(x => x.QuantityPerUnit).HasColumnName(@"QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName(@"UnitPrice");
            Property(x => x.UnitsInStock).HasColumnName(@"UnitsInStock");
            Property(x => x.UnitsOnOrder).HasColumnName(@"UnitsOnOrder");
            Property(x => x.ReorderLevel).HasColumnName(@"ReorderLevel");
            Property(x => x.Discontinued).HasColumnName(@"Discontinued");

            // Foreign keys
            HasOptional(a => a.Category).WithMany(b => b.Products).HasForeignKey(c => c.CategoryId).WillCascadeOnDelete(false); // FK_Products_Categories
        }
    }
}
