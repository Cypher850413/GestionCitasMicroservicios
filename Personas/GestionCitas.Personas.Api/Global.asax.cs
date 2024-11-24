using GestionCitas.Personas.Infraestrucutura.Repositorio;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios.Impl;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios;
using GestionCitas.Personas.Api.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Repositorios;

namespace GestionCitas.Personas.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configurar el contenedor de dependencias
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Crear el ServiceProvider y configurar el DependencyResolver
            var serviceProvider = services.BuildServiceProvider();
            GlobalConfiguration.Configuration.DependencyResolver = new DefaultDependencyResolver(serviceProvider);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Registrar dependencias aquí
            services.AddScoped<IMedicoCommandService, MedicoCommandService>();
            services.AddScoped<IMedicoQueriesService, MedicoQueriesService>();

            // Registra el repositorio
            services.AddScoped<IMedicoRepository, PersonaRepository>(); // Asegúrate de usar la implementación correcta
        }
    }
}
