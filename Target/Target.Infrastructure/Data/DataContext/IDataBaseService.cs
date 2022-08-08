using System.Data;

namespace Target.Infrastructure.Data.DataContext
{
    public interface IDataBaseService
    {
        public IDbConnection GetConnection();
    }
}
