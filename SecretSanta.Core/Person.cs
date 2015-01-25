namespace CWB.SecretSanta.Core
{
    /// <summary>
    /// Represents an individual who should both give and receive a gift
    /// </summary>
    public class Person : IHasId
    {
        /// <summary>
        /// The key by which we identify the item
        /// </summary>
        public int Id { get; set; }
    }
}
