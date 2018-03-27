namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Setup
{
    using Autofac;
    using Autofac.Integration.WebApi;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using Ilisimatusarfik.CourseCoordinator.DAL.Factories;
    using Ilisimatusarfik.CourseCoordinator.DAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;

    public static class DependencyInjection
    {
        public static void Initialize(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            Register(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void Register(ContainerBuilder builder)
        {
            var connectionString = "";
            builder.Register(_ => new ConnectionFactory(connectionString)).As<IConnectionFactory>();
            builder.RegisterType<LanguageRepository>().As<ILanguageRepository>();
        }
    }
}
