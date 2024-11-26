using GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios.Impl;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios;
//using GestionCitas.Personas.Api.Infraestructura;
using Unity;
using Unity.Lifetime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.WebApi;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Repositorios;
using GestionCitas.Personas.Infraestrucutura;
using GestionCitas.Personas.Infraestrucutura.Repositorio;

namespace GestionCitas.Personas.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var container = new UnityContainer();
            RegisterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        private void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IMedicoCommandService, MedicoCommandService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMedicoQueriesService, MedicoQueriesService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMedicoRepository, MedicoRepository>(new HierarchicalLifetimeManager()); 
            container.RegisterType<IPacienteCommandService, PacienteCommandService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPacienteQueriesService, PacienteQueriesService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPacienteRepository, PacienteRepository>(new HierarchicalLifetimeManager());

        }

        //private void ConfigureServices(IServiceCollection services)
        //{
        //    // Registrar dependencias aquí
        //    services.AddScoped<IMedicoCommandService, MedicoCommandService>();
        //    services.AddScoped<IMedicoQueriesService, MedicoQueriesService>();

        //    // Registra el repositorio
        //    //services.AddScoped<IMedicoRepository, PersonaRepository>(); // Asegúrate de usar la implementación correcta
        //}
    }
}
