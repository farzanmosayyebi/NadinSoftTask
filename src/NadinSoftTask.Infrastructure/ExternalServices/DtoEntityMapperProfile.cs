using AutoMapper;

using NadinSoftTask.Core.Models;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Dtos.Account;
using NadinSoftTask.Core.Dtos.Security;
using Microsoft.Extensions.Options;

namespace NadinSoftTask.Infrastructure.ExternalServices;

public class DtoEntityMapperProfile : Profile
{
    public DtoEntityMapperProfile()
    {
        CreateMap<ProductUpdateDto, Product>()
            .ForMember(dest => dest.Id, options => options.Ignore())
            .ForMember(dest => dest.Creator, options => options.Ignore());
        
        CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.Id, options => options.Ignore())
            .ForMember(dest => dest.Creator, options => options.Ignore());
        
        CreateMap<Product, ProductGetDto>()
            .ForMember(dest => dest.CreatorUserName, options => options.MapFrom(src => src.Creator.UserName));
        
        CreateMap<Product, Product>();

        CreateMap<ProductDetailsDto, ProductCreateDto>()
            .ForMember(dest => dest.CreatorId, options => options.Ignore());

        CreateMap<UserIdDto, ProductCreateDto>()
            .ForMember(dest => dest.CreatorId, options => options.MapFrom(src => src.UserId));

        CreateMap<UserRegisterDto, ApplicationUser>()
            .ForSourceMember(src => src.Password, opt => opt.DoNotValidate())
            .ForMember(dest => dest.CreatedProducts, opt => opt.NullSubstitute(new List<Product>()));
    }
}
