using AutoMapper;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Dtos.Security;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.ExternalServices;

public class DtoEntityMapperProfile : Profile
{
    public DtoEntityMapperProfile()
    {
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Creator, opt => opt.Ignore());
        CreateMap<Product, ProductGetDto>()
            .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.Creator.Id));
        CreateMap<Product, Product>();


    }
}
