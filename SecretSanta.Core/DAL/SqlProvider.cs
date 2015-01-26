using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CWB.SecretSanta.Core.DAL
{
    /// <summary>
    /// Used to retrieve a connection to a particular database
    /// </summary>
    public class SqlProvider : ISqlProvider
    {
        /// <summary>
        /// Create an instance which can be used to create connections using the supplied connection string
        /// </summary>
        public SqlProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private readonly string connectionString;

        public async Task<SqlConnection> GetConnection()
        {
            var connection = new SqlConnection {ConnectionString = connectionString};
            await connection.OpenAsync();
            return connection;
        }
    }
}