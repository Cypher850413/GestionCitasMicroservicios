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
using GestionCitas.Recetas.Dominio.Repositorios;
using GestionCitas.Recetas.Infraestructura;
using GestionCitas.Recetas.Infraestructura.Repositorio;
using GestionCitas.Recetas.Dominio.Servicios;
using GestionCitas.Recetas.Dominio.Servicios.Impl;
using Unity.AspNet.WebApi;

namespace GestionCitas.Recetas.Api
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
            container.RegisterType<IRecetaCommandService, RecetaCommandService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRecetaQueriesService, RecetaQueriesService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRecetaRepository, RecetaRepository>(new HierarchicalLifetimeManager());


        }
    }
}
