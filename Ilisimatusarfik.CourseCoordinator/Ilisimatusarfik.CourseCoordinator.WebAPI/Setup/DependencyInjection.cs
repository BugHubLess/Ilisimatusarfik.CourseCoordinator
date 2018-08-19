namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Setup
{
    using Autofac;
    using Autofac.Integration.WebApi;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using Ilisimatusarfik.CourseCoordinator.DAL.Factories;
    using Ilisimatusarfik.CourseCoordinator.DAL.Repositories;
    using Ilisimatusarfik.CourseCoordinator.WebAPI.Controllers;
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
            // "Server=(localdb)\\v11.0;Integrated Security=true;"
            var connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Ilisimatusarfik.Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            builder.Register(_ => new ConnectionFactory(connectionString)).As<IConnectionFactory>();

            // Controllers
            builder.RegisterType<LanguageController>();
            builder.RegisterType<StudyProgramController>();

            // Repositories
            builder.RegisterType<LanguageRepository>().As<ILanguageRepository>();
            builder.RegisterType<LectureStatusRepository>().As<ILectureStatusRepository>();
            builder.RegisterType<StudyProgramRepository>().As<IStudyProgramRepository>();
        }
    }
}