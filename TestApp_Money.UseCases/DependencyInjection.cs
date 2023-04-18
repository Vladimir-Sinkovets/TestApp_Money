using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using TestApp_Money.UseCases.Features.Records.Commands.CreateRecord;
using TestApp_Money.UseCases.Common;

namespace TestApp_Money.UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateRecordCommand)));
            });

            return services;
        }
    }
}
