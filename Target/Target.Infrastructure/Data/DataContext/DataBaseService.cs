using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Target.Infrastructure.Data.DataContext
{
    public class DataBaseService : IDataBaseService
    {
        private IConfiguration _configuration { get; }
        public DataBaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnection()
        {
            var sqlConnectionStringName = _configuration["ConnectionStrings:SqlServer"];
            return new SqlConnection(sqlConnectionStringName);
        }
    }
}
