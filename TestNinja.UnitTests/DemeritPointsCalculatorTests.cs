using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int error)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(error), 
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(65)]
        public void CalculateDemeritPoints_SpeedIsLessThanOrAtSpeedLimit_ReturnZero(int speed)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            
            Assert.That(result, Is.EqualTo(0));
        }
        
        [Test]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}