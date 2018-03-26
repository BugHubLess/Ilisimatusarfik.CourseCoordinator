namespace Ilisimatusarfik.CourseCoordinator.Commons.Factories
{
    using System.Data;

    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}