﻿using NUnit.Framework;
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
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnsTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}