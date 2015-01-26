using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWB.SecretSanta.Core.DAL
{
    /// <summary>
    /// Used to retrieve a connection to a particular database
    /// </summary>
    public interface ISqlProvider
    {
        /// <summary>
        /// Retrieves an open connection to the database
        /// </summary>
        /// <returns></returns>
        Task<SqlConnection> GetConnection();

    }
}
