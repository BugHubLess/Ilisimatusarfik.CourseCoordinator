namespace Ilisimatusarfik.CourseCoordinator.WebAPI
{
    using Ilisimatusarfik.CourseCoordinator.WebAPI.Setup;
    using Owin;
    using System.Web.Http;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            DependencyInjection.Initialize(config);

            appBuilder.UseWebApi(config);
        }
    }
}