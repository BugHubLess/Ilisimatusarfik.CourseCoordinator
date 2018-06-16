namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Setup
{
    using System.Web.Http;

    public static class Routes
    {
        public const string DefaultRouteName = "DefaultApi";

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: DefaultRouteName,
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}