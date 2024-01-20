using Microsoft.Data.SqlClient;

namespace Inventory.Data
{
    public class DataContext
    {
        public SqlConnection? Connection { get;private set; }
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration= configuration;
            Connection=new SqlConnection(_configuration.GetConnectionString("MyConection"));
            Connection?.Open();
        }

    }
}
