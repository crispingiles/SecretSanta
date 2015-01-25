using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CWB.SecretSanta.Core
{
    /// <summary>
    /// Used to check items based on their Id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HasIdEqualityComparer<T> : EqualityComparer<T> where T : IHasId
    {
        /// <summary>
        /// True if the objects are equal based on their ids
        /// </summary>
        public override bool Equals(T x, T y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return x.Id == y.Id;
        }

        /// <summary>
        /// Get the hashcode of the object based on its id
        /// </summary>
        public override int GetHashCode(T obj)
        {
            if (obj == null)
            {
                return -1;
            }
            return obj.GetHashCode();
        }
    }
}