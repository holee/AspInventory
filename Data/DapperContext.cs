using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _config;

        public DapperContext(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection 
                            => new SqlConnection(_config.GetConnectionString("MyConection"));

    }
}
