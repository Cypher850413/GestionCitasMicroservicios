using GestionCitas.Citas.Dominio.Servicios.Impl;
using GestionCitas.Citas.Dominio.Servicios;
using Unity;
using Unity.Lifetime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GestionCitas.Citas.Dominio.Repositorios;
using GestionCitas.Citas.Infraestructura;
using GestionCitas.Citas.Infraestructura.Repositorio;
using Unity.AspNet.WebApi;

namespace GestionCitas.Citas.Api
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
            container.RegisterType<ICitaCommandService, CitaCommandService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICitaQueriesService, CitaQueriesService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICitaRepository, CitaRepository>(new HierarchicalLifetimeManager());
            

        }
    }
}
