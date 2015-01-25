namespace CWB.SecretSanta.Core
{
    /// <summary>
    /// Used to denote objects we can uniquely identify by an id
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// The key by which we identify the item
        /// </summary>
        int Id { get; set; }
    }
}