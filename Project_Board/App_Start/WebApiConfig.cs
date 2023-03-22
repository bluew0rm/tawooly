using System.Web.Http;

namespace Project_Board
{
    public class WebApiConfig
    {
        public static void RegisterRoutes(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}
