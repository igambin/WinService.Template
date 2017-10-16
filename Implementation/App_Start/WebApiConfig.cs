using System.Web.Http;
using Owin;

namespace WinService.Implementation
{
    public class WebApiConfig
    {

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}",
                defaults: new { controller = "Service", action = "Status" }
            );

            appBuilder.UseWebApi(config);

            SwaggerConfig.Register(config);
        }
    }
}
