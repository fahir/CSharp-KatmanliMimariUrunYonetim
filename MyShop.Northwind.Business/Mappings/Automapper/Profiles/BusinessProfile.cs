using AutoMapper;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using Cart = MyShop.Northwind.Entities.Concrete.Cart;

namespace MyShop.Northwind.Business.Mappings.Automapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Category, Category>()
            .ForMember(o => o.Products, o => o.Ignore());

            CreateMap<Role, Role>()
            .ForMember(d => d.UserRoles, o => o.Ignore());

            CreateMap<User, User>()
            .ForMember(d => d.UserRoles, o => o.Ignore())
            .ForMember(d => d.OrderDetails, o => o.Ignore());

            CreateMap<UserRole, UserRole>()
            .ForMember(d => d.User, o => o.Ignore())
            .ForMember(d => d.Role, o => o.Ignore());
            
            CreateMap<ProductDetail, ProductDetail>();

            CreateMap<Product, Product>()
            .ForMember(d => d.Category, o => o.Ignore());

            CreateMap<Cart, Cart>()
            .ForMember(d => d.OrderDetails, o => o.Ignore());

            CreateMap<OrderDetail, OrderDetail>()
            .ForMember(d => d.Carts, o => o.Ignore())
            .ForMember(d => d.ShippingDetails, o => o.Ignore())
            .ForMember(d => d.Users, o => o.Ignore());

            CreateMap<ShippingDetail, ShippingDetail>()
            .ForMember(d => d.OrderDetails, o => o.Ignore());

        }
    }
}
