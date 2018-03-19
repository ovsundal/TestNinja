using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        //called before each test
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        //ignore a test
        //[Ignore("Because i wanted to!")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        //parametrized test
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnsTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnsOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

//            Assert.That(result, Is.Not.Empty);
//            
//            Assert.That(result.Count(), Is.EqualTo(3));
//            
//            Assert.That(result, Is.Ordered);
//            
//            Assert.That(result, Is.Unique);
//            
//            Assert.That(result, Does.Contain(1));
//            Assert.That(result, Does.Contain(3));
//            Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new[] {1, 3, 5}));
        }
        [Test]
        public void GetOddNumbers_LimitIsZero_ReturnsNoResult()
        {
            var result = _math.GetOddNumbers(0);

            Assert.IsFalse(result.Any());
        }
        [Test]
        public void GetOddNumbers_LimitLessThanZero_ReturnsNoResult()
        {
            var result = _math.GetOddNumbers(-5);

            Assert.IsFalse(result.Any());
        }
    }
}