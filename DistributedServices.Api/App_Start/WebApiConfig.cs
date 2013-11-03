using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace DistributedServices.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ClientRoutes(config);
        }

        private static void ClientRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ClientGetAll",
                routeTemplate: "api/clients",
                defaults: new { controller = "Clients", action = "GetAll" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
                );

            config.Routes.MapHttpRoute(
                name: "ClientGet",
                routeTemplate: "api/clients/{token}",
                defaults: new { controller = "Clients", action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
                );

            config.Routes.MapHttpRoute(
                name: "ClientPost",
                routeTemplate: "api/clients",
                defaults: new { controller = "Clients", action = "Post" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
                );

            config.Routes.MapHttpRoute(
                name: "ClientPut",
                routeTemplate: "api/clients/{token}",
                defaults: new { controller = "Clients", action = "Put" },
                constraints: new { httpMethod = new HttpMethodConstraint("PUT") }
                );

            config.Routes.MapHttpRoute(
                name: "ClientDelete",
                routeTemplate: "api/clients/{token}",
                defaults: new { controller = "Clients", action = "Delete" },
                constraints: new { httpMethod = new HttpMethodConstraint("DELETE") }
                );
        }
    }
}
