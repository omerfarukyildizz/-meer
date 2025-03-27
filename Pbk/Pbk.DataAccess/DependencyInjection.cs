using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pbk.DataAccess.Context;
using Pbk.DataAccess.Repositories;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Scrutor;
using Pbk.Core.Features.User;
using Microsoft.AspNetCore.Http;

namespace Pbk.DataAccess;
public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        //SqlServerUAT
        //SqlServer
        string connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
        });


        services.AddIdentityCore<AppUser>(cfr =>
        {
            cfr.Password.RequireNonAlphanumeric = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>();
     

        services.AddScoped<IUnitOfWork>(sv => sv.GetRequiredService<ApplicationDbContext>());
 

        services.Scan(selector => selector
            .FromAssemblies(
                typeof(DependencyInjection).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }
}