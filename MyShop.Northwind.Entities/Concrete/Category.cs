using OZBAY.Core.Entities;
using System.Collections.Generic;
namespace MyShop.Northwind.Entities.Concrete
{
  
    public partial class Category : IEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
