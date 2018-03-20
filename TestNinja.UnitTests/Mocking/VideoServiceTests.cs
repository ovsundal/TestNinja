using System;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _mockFileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_mockFileReader.Object);
            
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var result = _videoService.ReadVideoTitle();
            
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
//        [Test]
//        public void ReadVideoTitle_WhenCalled_ReturnEmptyString()
//        {
//            var result = _videoService.ReadVideoTitle();
//            
//            Assert.That(result, Does.Contain("").IgnoreCase);
//        }
    }
}