using AutoMapper;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.ExternalServices;

public class DtoEntityMapperProfile : Profile
{
    public DtoEntityMapperProfile()
    {
        CreateMap<ProductUpdate, Product>();
        CreateMap<ProductCreate, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Product, ProductGet>()
            .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.Creator.Id));
        CreateMap<Product, Product>();
    }
}
