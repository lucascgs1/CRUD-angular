using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data;
using CRUD.Data.Interfaces;
using CRUD.Services;
using CRUD.Services.Interfaces;

namespace CRUD.Api.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            if (services == null)
                throw new ArgumentNullException(nameof(services));

            #region repositorios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            #endregion

            #region servicos
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IEnderecoServices, EnderecoServices>();
            services.AddTransient<IClienteServices, ClienteServices>();
            #endregion
        }

    }
}
