using System;
using System.Data;
using System.Data.SqlClient;

namespace Lead.Management.Infrastruture.Repositories
{
    public class DapperRepository : IDisposable
    {
        protected string _connectionString;

        public DapperRepository(string connectionString) => _connectionString = connectionString;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
