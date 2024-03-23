using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

using NadinSoftTask.Application.Services;
using NadinSoftTask.Core.Interfaces;
using NadinSoftTask.Infrastructure.Data.Commands.Create;
using NadinSoftTask.Infrastructure.ExternalServices;

namespace NadinSoftTask.Application;

public class DependencyInjectionConfiguration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCommand)));

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjectionConfiguration));
    }
}
