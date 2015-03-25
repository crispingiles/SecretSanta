using System.Collections.Generic;
using System.Threading.Tasks;

namespace CWB.SecretSanta.Core.DAL
{
    /// <summary>
    /// Used to retrieve persons from the database
    /// </summary>
    public interface IPersonProvider
    {
        /// <summary>
        /// Get the person with the specified id
        /// </summary>
        Task<Person> GetPerson(int personId);

        /// <summary>
        /// Get the persons associated with a supplied list
        /// </summary>
        Task<IReadOnlyList<Person>> GetPersons(int listId);

        /// <summary>
        /// Save the person to the database
        /// </summary>
        Task<Person> SavePerson(Person person);
    }
}
