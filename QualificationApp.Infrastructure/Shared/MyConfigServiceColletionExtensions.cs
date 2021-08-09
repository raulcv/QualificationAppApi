using Microsoft.Extensions.DependencyInjection;
using QualificationApp.Domain.Interfaces.Parametro.Ocupacion;
using QualificationApp.Domain.Interfaces.Parametro.Pais;
using QualificationApp.Domain.Interfaces.Parametro.Usuario;
using QualificationApp.Infrastructure.Repositories.General;
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
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IOcupacionRepository, OcupacionRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ExceptionLogRepository>();
            return services;
        }
    }
}
