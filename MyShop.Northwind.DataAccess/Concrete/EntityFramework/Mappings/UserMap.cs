using MyShop.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id");
            Property(x => x.UserName).HasColumnName(@"UserName");
            Property(x => x.Hashword).HasColumnName(@"Hashword");
            Property(x => x.FirstName).HasColumnName(@"FirstName");
            Property(x => x.LastName).HasColumnName(@"LastName");
            Property(x => x.Email).HasColumnName(@"Email");

        }
    }
}
