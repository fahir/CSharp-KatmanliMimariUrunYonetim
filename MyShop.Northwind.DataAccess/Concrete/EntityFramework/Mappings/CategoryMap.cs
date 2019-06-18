using MyShop.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID");
            Property(x => x.CategoryName).HasColumnName(@"CategoryName");
            Property(x => x.Description).HasColumnName(@"Description");
            Property(x => x.Picture).HasColumnName(@"Picture");
        }
    }
}
