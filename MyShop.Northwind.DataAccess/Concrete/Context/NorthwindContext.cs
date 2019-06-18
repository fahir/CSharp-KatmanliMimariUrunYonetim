using System.Data.Entity;
using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.DataAccess.Concrete.Context
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
           : base("name=NorthwindContext")
        {
            Database.SetInitializer<NorthwindContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Categories { get; set; } // Categories       

        public DbSet<Cart> Carts { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<ShippingDetail> ShippingDetails { get; set; }
      
        public DbSet<Product> Products { get; set; } // Products
      
        public DbSet<Role> Roles { get; set; } // Roles
      
        public DbSet<User> Users { get; set; } // Users

        public DbSet<UserRole> UserRoles { get; set; } // UserRoles

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

          

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

           

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cart>()
               .HasMany(e => e.OrderDetails)
               .WithRequired(e => e.Carts)
               .HasForeignKey(e => e.CartId);

            modelBuilder.Entity<ShippingDetail>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.ShippingDetails)
                .HasForeignKey(e => e.ShippingDetailId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }
    }
}
