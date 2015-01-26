using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.SecretSanta.Core.DAL
{
    /// <summary>
    /// Used to retrieve persons from the database
    /// </summary>
    public class PersonProvider : IPersonProvider
    {
        /// <summary>
        /// Create an instance used to retrieve persons from the database
        /// </summary>
        public PersonProvider(ISqlProvider sqlProvider)
        {
            this.sqlProvider = sqlProvider;
        }

        private readonly ISqlProvider sqlProvider;

        public async Task<Person> GetPerson(int personId)
        {
            var cmdText = string.Format(@"{0}
WHERE p.PersonId = @personId", SelectPersonsFragment);

            using (var connection = await sqlProvider.GetConnection())
            {
                var cmd = new SqlCommand {CommandText = cmdText, Connection = connection};
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@personId",
                    SqlDbType = SqlDbType.Int,
                    Value = personId
                });
                var result = await ReadRowsAsync(cmd);
                return result.FirstOrDefault();
            }
        }

        public async Task<IReadOnlyList<Person>> GetPersons(int listId)
        {
            var cmdText = string.Format(@"{0} 
INNER JOIN dbo.ListPerson lp 
ON p.PersonId = lp.PersonId
WHERE lp.ListId = @listId", SelectPersonsFragment);

            using (var connection = await sqlProvider.GetConnection())
            {
                var cmd = new SqlCommand {CommandText = cmdText, Connection = connection};
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@listId",
                    SqlDbType = SqlDbType.Int,
                    Value = listId
                });
                return await ReadRowsAsync(cmd);
            }
        }

        private async Task<IReadOnlyList<Person>> ReadRowsAsync(SqlCommand cmd)
        {
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                var result = new List<Person>();
                while (reader.Read())
                {
                    var person = new Person();
                    person.Id = reader.GetInt32(0);
                    person.EmailAddress = reader.GetString(1);
                    result.Add(person);
                }
                return result;
            }
        }

        private const string SelectPersonsFragment = @"SELECT p.PersonId, p.EmailAddress 
FROM Person p ";
    }
}