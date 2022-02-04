using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(App.Restaurante.WebApi.Startup))]

namespace App.Restaurante.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            RouteConfig.RegisterRoutes(config);
            DIConfig.ConfigureInjector(config);
            WebApiConfig.Configure(config);

            app.UseWebApi(config);
        }
    }
}