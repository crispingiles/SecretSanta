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
            Assert.IsFalse(comparer.Equals(other, null), "One null and one non-null person should not compare as equal with operands reversed");
        }

        [Test]
        public void TestDifferentIdsNotEquivalent()
        {
            var comparer = new HasIdEqualityComparer<Person>();
            var one = new Person {Id = 10};
            var two = new Person {Id = 20};
            Assert.IsFalse(comparer.Equals(one, two), "Two person objects with different ids should not compare as equal");
            Assert.IsFalse(comparer.Equals(two, one), "Two person objects with different ids should not compare as equal with operands reversed");
        }

        [Test]
        public void TestEqualIdsEquivalent()
        {
            var comparer = new HasIdEqualityComparer<Person>();
            var one = new Person {Id = 10};
            var two = new Person {Id = 10};
            Assert.IsTrue(comparer.Equals(one, two), "Two person objects with same ids should compare as equal");
            Assert.IsTrue(comparer.Equals(two, one), "Two person objects with same ids should compare as equal with operands reversed");
        }

    }
}
