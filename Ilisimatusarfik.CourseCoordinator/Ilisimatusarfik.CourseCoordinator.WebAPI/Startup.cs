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
            Routes.Register(config);
            DependencyInjection.Initialize(config);

            appBuilder.UseWebApi(config);
        }
    }
}