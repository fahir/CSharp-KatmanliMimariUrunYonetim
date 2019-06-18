using Ozbay.Core.Entities;

namespace MyShop.Northwind.Entities.ComplexTypes
{
    using MyShop.Northwind.Entities.Concrete;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order Details")]
    public partial class OrderDetail : IEntity
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int ProductID { get; set; }

        [Column(TypeName = "money")]
        public virtual decimal UnitPrice { get; set; }

        public virtual short Quantity { get; set; }

        public virtual float Discount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

    }
}
