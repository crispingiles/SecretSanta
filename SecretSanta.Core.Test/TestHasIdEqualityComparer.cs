using NUnit.Framework;

namespace CWB.SecretSanta.Core.Test
{
    [TestFixture]
    public class TestHasIdEqualityComparer
    {

        [Test]
        public void TestBoth0NullEquivalent()
        {
            var comparer = new HasIdEqualityComparer<Person>();
            Assert.IsTrue(comparer.Equals(null, null), "Two null persons should compare as equal");
        }

        [Test]
        public void TestOnlyOneNullNotEquivalent()
        {
            var comparer = new HasIdEqualityComparer<Person>();
            var other = new Person {Id = 10};
            Assert.IsFalse(comparer.Equals(null, other), "One null and one non-null person should not compare as equal");
            Assert.IsFalse(comparer.Equals(other, null), "One null and one non-null person should not compare as equal");
        }

    }
}
