namespace CWB.SecretSanta.Core
{
    /// <summary>
    /// Represent a collection of <see cref="Person"/>s who should have some shared property e.g. can give each other gifts, or mustn't give each other gifts
    /// </summary>
    public interface IPersonGroup
    {

        /// <summary>
        /// Add a person to the group
        /// </summary>
        /// <returns>True if the person was added to the group, false if was already present</returns>
        bool Add(Person person);

        /// <summary>
        /// Remove the person from the group
        /// </summary>
        /// <returns>True if the person was present in the group before removal</returns>
        bool Remove(Person person);

    }
}
