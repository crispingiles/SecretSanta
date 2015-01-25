using System.Collections.Generic;

namespace CWB.SecretSanta.Core
{
    /// <summary>
    /// Represent a collection of <see cref="Person"/>s who should have some shared property e.g. can give each other gifts, or mustn't give each other gifts
    /// </summary>
    public class PersonGroup : IPersonGroup
    {
        /// <summary>
        /// Create an instance to represent a collection of <see cref="Person"/>
        /// </summary>
        public PersonGroup()
        {
        }

        private  readonly  HashSet<Person> persons= new HashSet<Person>(new HasIdEqualityComparer<Person>()); 

        /// <summary>
        /// Add a person to the group
        /// </summary>
        /// <returns>True if the person was added to the group, false if was already present</returns>
        public bool Add(Person person)
        {
            return persons.Add(person);
        }

        /// <summary>
        /// Remove the person from the group
        /// </summary>
        /// <returns>True if the person was present in the group before removal</returns>
        public bool Remove(Person person)
        {
            return persons.Remove(person);
        }
    }

    
}
