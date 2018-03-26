namespace Ilisimatusarfik.CourseCoordinator.DAL.Factories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using System.Data;
    using System.Data.SqlClient;

    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;

        public ConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
