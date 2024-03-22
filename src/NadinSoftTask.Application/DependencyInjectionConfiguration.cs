using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NadinSoftTask.Application.Services;
using NadinSoftTask.Core.Interfaces;
using NadinSoftTask.Core.Models;
using NadinSoftTask.Infrastructure.Data;
using NadinSoftTask.Infrastructure.Data.Commands.Create;
using NadinSoftTask.Infrastructure.Data.Queries;
using NadinSoftTask.Infrastructure.ExternalServices;
using System.Reflection;

namespace NadinSoftTask.Application;

public class DependencyInjectionConfiguration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCommand)));

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAccountService, AccountService>();
        // Add Validators
    }
}
