
using Pbk.Core.Behaviors;
using Pbk.Entities.Models;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Pbk.Core;
public static class DependencyInjection
{
   public static IServiceCollection AddBusinessCore(
        this IServiceCollection services)
    {
        services.AddMediatR(cfr =>
        {
            cfr.RegisterServicesFromAssemblies(
                typeof(DependencyInjection).Assembly,
         
              typeof(AppUser).Assembly);
            cfr.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddMediatR(cfr =>
        {
            cfr.RegisterServicesFromAssemblies(
                typeof(DependencyInjection).Assembly,

              typeof(AppUser).Assembly);
            cfr.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
       
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        return services;
    }
}
