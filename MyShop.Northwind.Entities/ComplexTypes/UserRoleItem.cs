namespace MyShop.Northwind.Entities.ComplexTypes
{
    public class UserRoleItem
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
    }
}
