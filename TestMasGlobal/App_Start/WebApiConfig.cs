using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TestMasGlobal.Controllers.Helpers;
using TestMasGlobal.Domains.Actions.GetEmployees;
using TestMasGlobal.Domains.UseCases;
using TestMasGlobal.Ports.ExternalAPI;
using Unity;
using Unity.Lifetime;

namespace TestMasGlobal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IGetAllEmployees, EmployeeAPIRequest>(new ContainerControlledLifetimeManager());
            container.RegisterType<IGetEmployeeById, EmployeeAPIRequest>(new ContainerControlledLifetimeManager());
            container.RegisterType<IListEmployee, ListEmployee>(new ContainerControlledLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            var corsConfig = new EnableCorsAttribute("*", "*", "*");

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(corsConfig);
        }
    }
}
