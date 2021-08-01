using Microsoft.Extensions.DependencyInjection;
using QualificationApp.Domain.Interfaces.Parametro.Pais;
using QualificationApp.Infrastructure.Repositories.Parametro.Pais;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Interfaces.Shared
{
    public static class MyConfigServiceColletionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services)
        {
            //services.AddTransient<IOcupacionRepository, OcupacionRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
