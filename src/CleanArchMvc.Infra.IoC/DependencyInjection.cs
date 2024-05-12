using AutoMapper;
using CleanArchMvc.Application.AutoMapper;
using CleanArchMvc.Application.Services._Category;
using CleanArchMvc.Application.Services._Product;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        //Connection String and Context register
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                                );
        });

        //Automapper services register
        var mappingConfig = new MapperConfiguration(options =>
        {
            options.AddProfile(new MappingProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        //Repositories services register
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        //Services "services" register (funny yes?! rsr)
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
