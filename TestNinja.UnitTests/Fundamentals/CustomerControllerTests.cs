using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _customerController;

        //called before each test
        [SetUp]
        public void SetUp()
        {
            _customerController = new CustomerController();
        }
        
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var result = _customerController.GetCustomer(0);
            
            //result is a NotFound object
            Assert.That(result, Is.TypeOf<NotFound>());
            
            //result is a NotFound or derivative object
            Assert.That(result, Is.InstanceOf<NotFound>());
        }
        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var result = _customerController.GetCustomer(1);
            
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}