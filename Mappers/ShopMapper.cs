using AutoMapper;
using net_shop_back.Entities;
using net_shop_back.Models;

namespace net_shop_back.Mappers
{
    public class ShopMapper : Profile
    {
        public ShopMapper()
        {
            CreateMap<Group, GroupModel>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<Subgroup, SubgroupModel>();
            CreateMap<Subgroup, SubgroupCardModel>();
            CreateMap<Product, ProductModel>();
            CreateMap<Product, ProductCardModel>();
            CreateMap<Photo, PhotoModel>();
            CreateMap<Photo, PhotoForCardModel>();
            CreateMap<ProductDescription, ProductDescriptionModel>();
            CreateMap<ProductDescription, DescriptionForCardModel>();
        }
    }
}
